using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsPanel : MonoBehaviour
{
    [SerializeField] private Image[] _hearts;

    [SerializeField] Sprite fullHeart, emptyHeart;

    private int _heartsCount;

    private int _maxHearts = 3;

    private void Awake()
    {
        ResetHearts();
    }
    private void OnEnable()
    {
        ResetHearts();
    } 
    private void OnDisable()
    {
        ResetHearts();
    }
    public void ReduceHearts()
    {
        _heartsCount--;
        _hearts[_heartsCount].sprite = emptyHeart;
    }

    public void ResetHearts()
    {
        foreach(var heart in _hearts)
        {
            _heartsCount = _maxHearts;
            heart.sprite = fullHeart;
        }
    }
  
}
