using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField]
    private Image _backgroundRenderer;

    [SerializeField]
    private Image _doorsRenderer;

   public void ChangeBackground(Sprite background)
        => _backgroundRenderer.sprite = background;

    public void ChangeDoorsRender(Sprite door)
        => _doorsRenderer.sprite = door;

}
