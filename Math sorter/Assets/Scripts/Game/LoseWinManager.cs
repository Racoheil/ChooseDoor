using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseWinManager : MonoBehaviour
{
    [SerializeField] 
    private SpriteRenderer[] _collectedGiftsHolders;

    [SerializeField]
    private GameObject _winObjects, _loseObjects;

    private int _countOfCollectedGifts;

    private List<Sprite> _collectedGifts;

    ISaveService _prefsSaveService;
    private void Awake()
    {
        _prefsSaveService = new PrefsSaveService();

        _winObjects.gameObject.SetActive(false); 
        _loseObjects.gameObject.SetActive(false);
        _collectedGifts = new List<Sprite>();
    }
    private void OnEnable()
    {
        EventService.OnLevelWin += DoOnWin;
        EventService.OnLevelLose += DoOnLose;
    }

    private void OnDisable()
    {
        EventService.OnLevelWin -= DoOnWin;
        EventService.OnLevelLose -= DoOnLose;
    }
    public void DoOnWin()
    {
        var levelIndex=FindObjectOfType<LevelsManager>().CurrentLevelIndex;
        AnalyticsService.Instance.SendLevelCompleteEvent(levelIndex);
        LoadCollectedGifts();
        _loseObjects.gameObject.SetActive(false);
        _prefsSaveService.SaveCompletedLevel(DataHolder.GetSelectedLevel());
    }

    public void DoOnLose()
    {
        var levelIndex=FindObjectOfType<LevelsManager>().CurrentLevelIndex;
        AnalyticsService.Instance.SendLevelFailedeEvent(levelIndex);
        _winObjects.gameObject.SetActive(false);
        ShowLoseObjects();
    }
    public void LoadCollectedGifts()
    {
        _winObjects.gameObject.SetActive(true);
        for(int i = 0;i< _collectedGifts.Count; i++)
        {
            _collectedGiftsHolders[i].sprite = _collectedGifts[i];
        }
      //  Debug.Log("_collectedGifts.Count: " + _collectedGifts.Count);
       // Debug.Log("_collectedGiftsHolders.Length: " + _collectedGiftsHolders.Length);

        for (int i = _collectedGifts.Count; i < _collectedGiftsHolders.Length; i++)
        {
          //  Debug.Log("Number of gift: " + i);
            _collectedGiftsHolders[i].gameObject.SetActive(false);
        }
    }
    public void ShowLoseObjects()
    {
        _loseObjects.gameObject.SetActive(true);
    }

    public void AddGiftSprite(Sprite sprite,int giftId)
    {
        _collectedGifts.Add(sprite);
    }

}
