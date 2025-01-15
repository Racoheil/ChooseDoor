using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Example Item", menuName = "Level/New Example Item", order = 1)]
public class ExampleData : ScriptableObject
{
    [SerializeField] private string _example;

    [SerializeField] private string _rightAnswer;

    [SerializeField] private string[] _wrongAnswers;

    public string Example => _example;

    public string RightAnswer => _rightAnswer;

    public string[] WrongAnswers => _wrongAnswers;
 
}
