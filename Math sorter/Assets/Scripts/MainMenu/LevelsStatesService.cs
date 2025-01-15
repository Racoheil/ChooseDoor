using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsStatesService : MonoBehaviour
{
    [SerializeField]
    private Button[] _levelsButtons;

    [SerializeField]
    private Sprite _closedLevelImage, _openedLevelImage, _completedLevelImage;
    private enum LevelState { Closed = 0, Opened = 1, Completed = 2 }

    [SerializeField]
    Image[] allLocks;

    private int _numberOfLevels;

    ISaveService _prefsSaveService;

    int[] levelsStatesArray;

    public static LevelsStatesService instance;
    


    private void Awake()
    {
        instance = this;
        _numberOfLevels = _levelsButtons.Length;
        _prefsSaveService = new PrefsSaveService();
        LoadLevelImages();
    }
    

    private void OnEnable()
    {
       
    }
    private void OnDisable()
    {

    }

    public int GetNumberOfLevels()
    {
        return _numberOfLevels;
    }
    public void LoadLevelImages()
    {
        if (PlayerPrefs.HasKey(_prefsSaveService.GetLevelsStatesArrayKey()) == true)
        {
            levelsStatesArray = _prefsSaveService.GetAllLevelsStates();
            for (int i = 0; i < _numberOfLevels; i++)
            {
                switch (levelsStatesArray[i])
                {
                    case (int)(LevelState.Closed):

                        _levelsButtons[i].image.sprite = _closedLevelImage;
                        allLocks[i].enabled = true;
                        break;

                    case (int)(LevelState.Opened):

                        _levelsButtons[i].image.sprite = _openedLevelImage;
                        allLocks[i].enabled = false;
                        break;

                    case (int)(LevelState.Completed):

                        _levelsButtons[i].image.sprite = _completedLevelImage;
                        allLocks[i].enabled = false;
                        break;

                    default:

                        break;
                }
            }
        }
        else
        {
            levelsStatesArray = new int[_numberOfLevels];
            levelsStatesArray[0] = (int)(LevelState.Opened);
            print(levelsStatesArray[0]);
            _prefsSaveService.SaveLevelsStates(levelsStatesArray);
            LoadLevelImages();
            Debug.Log("First!");
        }
    }
    public int[] GetLevelsStatesArray()
    {
        return _prefsSaveService.GetAllLevelsStates();
    }
}
