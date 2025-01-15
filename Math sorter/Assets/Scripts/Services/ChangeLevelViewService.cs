using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelViewService : MonoBehaviour
{
    [SerializeField]
    private GraphicsConfig _backgroundConfig;

    [SerializeField]
    private GraphicsConfig _doorsConfig;

    [SerializeField]
    private GraphicsConfig _positiveGiftsConfig;

    [SerializeField]
    private GraphicsConfig _negativeGiftsConfig;

    [SerializeField]
    private LevelView _levelView;

    [SerializeField]
    private GameObject[] _doorsButtons;
}
