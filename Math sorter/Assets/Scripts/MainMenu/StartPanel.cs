using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;

    private void Start()
    {
        if (DataHolder.GetFirstOpenState() == true)
        {
            _startPanel.gameObject.SetActive(true);
          //  EventService.CallOnFirstOpen();
        }
        else _startPanel.gameObject.SetActive(false);
    }
    public void CloseStartPanel()
    {
        StartCoroutine(CloseStartPanelRoutine()); 
    }

    IEnumerator CloseStartPanelRoutine()
    {
       
        EventService.CallOnButtonClick();
        yield return new WaitForSeconds(0.5f);
        _startPanel.SetActive(false);
        DataHolder.SetFirstOpenState(false);
    }
}
