using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    [SerializeField]
    private LevelData[] _levelsItems;

    [SerializeField]
    QuestionPanel _questionPanel;

    [SerializeField]
    private TMP_Text[] _answersText;

    [SerializeField]
    private TMP_Text _questionsCountText;

    [SerializeField]
    private GiftsBackPack _giftsBackPack;

    [SerializeField]
    private int _currentLevelIndex;

    public int CurrentLevelIndex => _currentLevelIndex;

    [SerializeField]
    HealthSystemService _healthSystemService;

    private int _currentQuestionIndex;

    private string _rightAnswer;

    private string[] _wrongAnswers;

    private List<int> _randomNumbers = new List<int>();

    private string _currentQuestion;

    private void Awake()
    {
        _currentLevelIndex = DataHolder.GetSelectedLevel();
        _currentQuestionIndex = 0;
        LoadQuestionItems();
    }

    private void Start()
    {
        SetGiftsCount();
    }

    private void OnEnable()
    {
        EventService.OnDoorClicked += ProcessSelectedAnswer;
        EventService.OnNextQuestionRun += RunNextQuestion;
    }

    private void OnDisable()
    {
        EventService.OnDoorClicked -= ProcessSelectedAnswer;
        EventService.OnNextQuestionRun -= RunNextQuestion;
    }

    private void LoadQuestionItems()
    {
        _currentQuestion = _levelsItems[_currentLevelIndex].Examples[_currentQuestionIndex].Example;
        string currentQuestionNumber = (_currentQuestionIndex + 1).ToString();
        _questionsCountText.text = currentQuestionNumber + " / " + _levelsItems[_currentLevelIndex].Examples.Length;
        _questionPanel.SetText(_currentQuestion);
        LoadAllAnswers();
    }

    private void LoadAllAnswers()
    {
        GenerateRandomNumbers();
        SetRightAnswer();
        SetWrongAnswers();
        string[] allAnswers = { _rightAnswer, _wrongAnswers[0], _wrongAnswers[1] };

        for (int i = 0; i < _answersText.Length; i++)
        {
            _answersText[_randomNumbers[i]].text = allAnswers[i];
        }
    }

    private void SetGiftsCount()
    {
        int giftsCount = _levelsItems[_currentLevelIndex].Examples.Length;
        _giftsBackPack.SetGiftsCount(giftsCount);
    }

    private void SetRightAnswer()
    {
        _rightAnswer = _levelsItems[_currentLevelIndex].Examples[_currentQuestionIndex].RightAnswer;
    }

    private void SetWrongAnswers()
    {
        _wrongAnswers = new string[_levelsItems[_currentLevelIndex].Examples[_currentQuestionIndex].WrongAnswers.Length];

        for (int i = 0; i < 2; i++)
        {
            _wrongAnswers[i] = _levelsItems[_currentLevelIndex].Examples[_currentQuestionIndex].WrongAnswers[i];
        }
    }

    private void GenerateRandomNumbers()
    {
        _randomNumbers.Clear();
        while (_randomNumbers.Count < 3)
        {
            int randomNumber = Random.Range(0, 3);

            if (!_randomNumbers.Contains(randomNumber))
            {
                _randomNumbers.Add(randomNumber);
            }
        }
    }

    private void ProcessSelectedAnswer()
    {
        DoorButton door = DoorsPanelService.s_instance.SelectedDoorButton;
        string selectedAnswer = door.AnswerText;
        
        if(selectedAnswer == _rightAnswer)
        {
            EventService.CallOnRightAnswerSelected();
            StartCoroutine(SetRightAnswerRoutine(selectedAnswer));
        }

        else if(selectedAnswer!= _rightAnswer)
        {
            EventService.CallOnWrongAnswerSelected();
            StartCoroutine(SetWrongAnswerRoutine(selectedAnswer));
        }
    }

    public void RunNextQuestion()
    {
        int examplesCount = _levelsItems[_currentLevelIndex].Examples.Length;
        int health = _healthSystemService.GetHealth();
        Debug.Log("_currentQuestionIndex=" + _currentQuestionIndex);
        Debug.Log("examplesCount=" + examplesCount);

        if (_currentQuestionIndex+1==examplesCount) 
        {
            if (_healthSystemService.GetHealth() > 0)
            {
                Debug.Log("Health = " + health);
                EventService.CallOnLevelWin();
            }
        }
        else if (_currentQuestionIndex + 1 != examplesCount)
        {
            _currentQuestionIndex++;
            LoadQuestionItems();
        }
    }
    private IEnumerator SetRightAnswerRoutine(string answer)
    {
        yield return new WaitForSeconds(0.5f);
        _questionPanel.SetRightAnswer(answer);
    }
    private IEnumerator SetWrongAnswerRoutine(string answer)
    {
        yield return new WaitForSeconds(0.5f);
        _questionPanel.SetWrongAnswer(answer); 
    }
    private IEnumerator WinRoutine()
    {
        yield return new WaitForSeconds(0.5f);
    }
    private IEnumerator LoseRoutine()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
