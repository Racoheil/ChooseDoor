using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class GiftHolderManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _shakingObject; 
    
    [SerializeField]
    private GraphicsConfig[] _positiveGiftsItems;

    [SerializeField]
    private GraphicsConfig _negativeGiftItem;

    [SerializeField]
    private GiftHolder _giftHolder;

    [SerializeField]
    private GameObject _giftsBackPack;

    [SerializeField]
    private DamagePicture _damagePicture;

    [SerializeField]
    private LoseWinManager _loseWinManager;

    private int _giftNumber;

    private Coroutine _enabledCoroutine;

    private List<int> _collectedGiftsId = new List<int>();

    [SerializeField]
    private ISaveService _prefsSaveService;
    
    private void Awake()
    {
        _giftNumber = 0;
        _prefsSaveService = new PrefsSaveService();
    }

    private void OnEnable()
    {
        EventService.OnRightAnswerSelected += DoActionsOnRightAnswer;
        EventService.OnWrongAnswerSelected += DoActionsOnWrongAnswer;
        EventService.OnLevelWin += SaveAllColelctedGifts;
    }

    private void OnDisable()
    {
        EventService.OnRightAnswerSelected -= DoActionsOnRightAnswer;
        EventService.OnWrongAnswerSelected -= DoActionsOnWrongAnswer;
        EventService.OnLevelWin -= SaveAllColelctedGifts;
    }

    private void DoActionsOnRightAnswer()
    {
        int selectedLevel = DataHolder.GetSelectedLevel();

        _giftHolder.ActivateObject();
        DoorButton door = DoorsPanelService.s_instance.SelectedDoorButton;
        Sprite giftSprite = _positiveGiftsItems[selectedLevel].Graphics[_giftNumber];
        int giftId = _giftNumber+ (_positiveGiftsItems[selectedLevel].Graphics.Count * selectedLevel);
       // Debug.Log("We saved gift number" +  giftId);
        _collectedGiftsId.Add(giftId);

        ChangeGiftHolderImage(giftSprite);
        _giftHolder.MoveGiftHolderToDoor(door.transform.position);
        _giftNumber++;
        _enabledCoroutine = StartCoroutine(RightAnswerAnimationRoutine());

        _loseWinManager.AddGiftSprite(giftSprite, _giftNumber );
    }

    private void DoActionsOnWrongAnswer()
    {
        _giftHolder.ActivateObject();
        DoorButton door = DoorsPanelService.s_instance.SelectedDoorButton;
        ChangeGiftHolderImage(_negativeGiftItem.Graphics[0]);
        _giftHolder.MoveGiftHolderToDoor(door.transform.position);
        _giftNumber++;
        _enabledCoroutine = StartCoroutine(WrongAnswerAnimationRoutine());
    }

    private void ChangeGiftHolderImage(Sprite sprite)
    {
        _giftHolder.ActivateObject();
        _giftHolder.ChangeGiftSprite(sprite);
    }

    private IEnumerator RightAnswerAnimationRoutine()
    {
        yield return new WaitForSeconds(0.25f);
        EventService.CallOnRightAnswerSound();
        yield return new WaitForSeconds(0.25f);
        EventService.CallOnRightAnswerHighlight();
        yield return new WaitForSeconds(0.25f);
        
        _giftHolder.transform.DOMove(_giftsBackPack.transform.position, 1f);
        _giftHolder.transform.DOScale(0.5f, 1f);
        
        yield return new WaitForSeconds(0.5f);
        EventService.CallOnTakeGift();
        yield return new WaitForSeconds(0.5f);
        _giftHolder.DeActivateObject();
        _giftHolder.transform.DOScale(1f, 0f);
        EventService.CallOnNextQuestionRun();
    }

    private IEnumerator WrongAnswerAnimationRoutine()
    {
        float shakeStrenght = 200f;
        yield return new WaitForSeconds(0.45f);
        EventService.CallOnWrongAnswerSound();
        yield return new WaitForSeconds(0.30f);

        EventService.CallOnTakeDamageSound();
        yield return new WaitForSeconds(0.1f);

        _giftHolder.ZoomInGiftHolder(20f);

        yield return new WaitForSeconds(0.1f);
        EventService.CallOnTakeDamage();
        
        _damagePicture.ActivateDamagePicture();
        _giftHolder.transform.DOShakePosition(0.2f, 100f, 10, 0f);
        _shakingObject.transform.DOShakePosition(1f, shakeStrenght, 10, 0f);
        yield return new WaitForSeconds(0.25f);

        _giftHolder.ReturnToPreviousPosition();
        _giftHolder.ZoomOutGiftHolder();
        yield return new WaitForSeconds(0.5f);

        _damagePicture.DeactivateDamagePicture();
        _giftHolder.DeActivateObject();
        yield return new WaitForSeconds(0.45f);
        EventService.CallOnNextQuestionRun();
    }

    public void SaveAllColelctedGifts()
    {
        foreach(int gift in _collectedGiftsId)
        {
            //Debug.Log("Save gift number " + gift);
            _prefsSaveService.SaveCollectedGift(gift);
        }
        
    }
}
