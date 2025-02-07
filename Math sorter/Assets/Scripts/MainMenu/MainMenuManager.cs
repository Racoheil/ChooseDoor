using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using YG;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenuPanel;

    [SerializeField]
    private GameObject _collectionPanel;

    [SerializeField]
    private TextMeshPro _giftsCountText;


    private ISaveService _prefsSaveService;
    private void Awake()
    {
        _prefsSaveService = new PrefsSaveService();
        SetCountOfGifts();

    }
    private void Start()
    {
        //YandexGame.FullscreenShow();
    }
    public void GoToCollection()
    {
        StartCoroutine(OpenCollectionRoutine());
        EventService.CallOnCollectionOpen();
    }

    public void GoToMainMenu()
    {
        StartCoroutine(CloseCollectionRoutine());
        EventService.CallOnCollectionClose();
    }

    public void SetCountOfGifts()
    {
        bool[] openedGiftsArray= _prefsSaveService.LoadCollectedGifts();
        int allGiftsCount = _prefsSaveService.GetAllGiftsCount();
        int openedGiftsCount = openedGiftsArray.Count(x => x == true);
        _giftsCountText.text = $"{openedGiftsCount}/{allGiftsCount}";
    }

    IEnumerator OpenCollectionRoutine()
    {
        EventService.CallOnBackpackOpen(0.5f);
        yield return new WaitForSeconds(0.5f);
        _mainMenuPanel.SetActive(false);
        _collectionPanel.SetActive(true);
    }
    IEnumerator CloseCollectionRoutine()
    {
        yield return new WaitForSeconds(0);
        
        _mainMenuPanel.SetActive(true);
        _collectionPanel.SetActive(false);
        EventService.CallOnBackpackClose(0.5f);
    }

}
