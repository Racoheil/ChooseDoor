using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _questionText;

    public void SetText(string text)
    {
        _questionText.text = text; 
    }

    public void SetRightAnswer(string answer)
    {
        string questionText = _questionText.text;
        _questionText.text = questionText.Substring(0, _questionText.text.Length-1) + $"<color=green>{answer}</color>";
    }

    public void SetWrongAnswer(string answer)
    {
        string questionText = _questionText.text;
        _questionText.text = questionText.Substring(0, _questionText.text.Length - 1) + $"<color=red>{answer}</color>";
    }
}
