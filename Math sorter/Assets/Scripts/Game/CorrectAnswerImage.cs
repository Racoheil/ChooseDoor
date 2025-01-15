using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectAnswerImage : MonoBehaviour
{
    [SerializeField]private Image _correctImage;
    Gradient _gradient;
    private Color _targetColor;
    private float _duration;
    private float _colorVisiblity = 0.430f;

    private void Awake()
    {
        _targetColor = Color.green;
        _targetColor.a = _colorVisiblity;
        _duration = 0.45f;
      _correctImage.enabled = false;
    }

    private void OnEnable()
    {
        EventService.OnRightAnswerHighlight += HighlightImage;
    }

    private void OnDisable()
    {
        EventService.OnRightAnswerHighlight -= HighlightImage;

    }

    public void HighlightImage()
    {
        _correctImage.enabled=true;
        StartCoroutine(HighlightImageRoutine());
    }

    IEnumerator HighlightImageRoutine()
    {
        // _correctImage

        Color startColor = _correctImage.color;
        startColor.a = _colorVisiblity;
        float elapsedTime = 0f;
        while (elapsedTime < _duration)
        {
            float t = elapsedTime / _duration;
            _correctImage.color = Color.Lerp(startColor, _targetColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _correctImage.color = _targetColor;
        elapsedTime = 0f;
        while (elapsedTime < _duration)
        {
            float t = elapsedTime / _duration;
            _correctImage.color = Color.Lerp(_targetColor, startColor, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _correctImage.color = startColor;
    }
}
