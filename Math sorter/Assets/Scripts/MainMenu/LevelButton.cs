using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private int _indexOfLevel;

    private const string LoadedScene = "Game";

    public bool isOpenState;

    private Button button;

    [SerializeField]
    private TMP_Text numberOfLevelText;

    private int numberOfLevel;

    public void Awake()
    {
        numberOfLevel = this.transform.GetSiblingIndex()+1;
        _indexOfLevel = transform.GetSiblingIndex();
        button = GetComponent<Button>();
    }
    
    public void Start()
    {
        SetNumberOfLevel();
        SetOpenState();
    }
    
    public void SetOpenState()
    {
       int[] array= LevelsStatesService.instance.GetLevelsStatesArray();
       int buttonId = button.transform.GetSiblingIndex();
       if (array[buttonId] == 0)
       {
            isOpenState = false;
            
       }
       else isOpenState = true;
    }
    
    public void SetNumberOfLevel()
    {

        numberOfLevelText.text = "Level " + numberOfLevel.ToString();
    }


    public void SelectLevel()
    {
        if (isOpenState)
        {
            AnalyticsService.Instance.SendLevelStartEvent(_indexOfLevel);
            StartCoroutine(SelectLevelRoutine());
        }
    }

    private IEnumerator SelectLevelRoutine()
    {
        EventService.CallOnLevelSelect();
        yield return new WaitForSeconds(0.5f);
        DataHolder.SetSelectedLevel(_indexOfLevel);
        SceneManager.LoadScene(LoadedScene);
    }
}
