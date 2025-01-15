using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GiftsBackPack : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _giftsCountText;

    private int _giftsCount;

    private int _counterOfGifts;

    private void Awake()
    {
        _giftsCount = 0;
    }

    private void OnEnable()
    {
        EventService.OnTakeGift += IncreaseGiftsCount;
        EventService.OnRightAnswerSelected += OpenBackPack;
    }

    private void OnDisable()
    {
        EventService.OnTakeGift -= IncreaseGiftsCount;
        EventService.OnRightAnswerSelected -= OpenBackPack;
    }

    public void SetGiftsCount(int count)
    {
        _giftsCount = count;
        SetGiftsCountText(count);
    }

    public int GetGiftsCount()
    {
        return _giftsCount;
    }

    private void IncreaseGiftsCount()
    {
        _counterOfGifts++;
        SetGiftsCountText(_giftsCount);
    }

    private void SetGiftsCountText(int count)
    {
        _giftsCountText.text =  _counterOfGifts.ToString() + " / " + count.ToString();
    }
    private void OpenBackPack()
    {
        StartCoroutine(BackpackOpenRoutine());
    }
    private void CloseBackPack()
    {
        StartCoroutine(BackpackCloseRoutine());
    }
    IEnumerator BackpackOpenRoutine()
    {
        yield return new WaitForSeconds(0.8f);
        EventService.CallOnBackpackOpen(0.45f);
        yield return new WaitForSeconds(0.1f);
        CloseBackPack();
    }
    IEnumerator BackpackCloseRoutine()
    {
        yield return new WaitForSeconds(0.8f);
        EventService.CallOnBackpackClose(0.25f);

    }
}
