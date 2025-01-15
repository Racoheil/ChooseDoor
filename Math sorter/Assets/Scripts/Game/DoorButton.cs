using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DoorButton : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    [SerializeField]private TMP_Text _answerText;

    private Button _button;

    private int _doorIndex;

    private DoorButton _doorButton;

    private bool _isClickable;

    public int DoorIndex => _doorIndex;

    public string AnswerText => _answerText.text;
    

    private void Awake()
    {
        _isClickable = true;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickOnTheDoor);
        _answerText = GetComponentInChildren<TMP_Text>();
        _doorIndex = transform.GetSiblingIndex();
        _doorButton = this;
    }

    private void OnEnable()
    {
        EventService.OnNextQuestionRun += ActivateClickability;
        EventService.OnDoorClicked += DeactivateClickability;
        EventService.OnNextQuestionRun += CloseDoor;
    }

    private void OnDisable()
    {
        EventService.OnNextQuestionRun -= ActivateClickability;
        EventService.OnDoorClicked -= DeactivateClickability;
        EventService.OnNextQuestionRun -= CloseDoor;
    }
    public void ActivateClickability()
    {
        _button.interactable = true;
    }

    public void DeactivateClickability()
    {
        _button.interactable = false;
    }

    public void ClickOnTheDoor()
    {
        DoorsPanelService.s_instance.SelectedDoorButton = _doorButton;
        EventService.CallOnDoorClicked();
        StartCoroutine(DoorOpenAnimationRoutine());
    }

    IEnumerator DoorOpenAnimationRoutine()
    {
        float durationOfMove = 0f;
        Vector3 newRotation = new Vector3(0, 170f, 0);
        Vector3 newPosition = new Vector3(0.75f,0,0.06f);
        door.transform.DOLocalMove(newPosition, durationOfMove);
        door.transform.DOLocalRotate(newRotation, durationOfMove); 
        yield return new WaitForSeconds(1f);
    }
    private void CloseDoor()
    {
        StartCoroutine(DoorCloseAnimationRoutine());
    }
    IEnumerator DoorCloseAnimationRoutine()
    {
        float durationOfMove = 0f;
        Vector3 newRotation = new Vector3(0, 0, 0);
        Vector3 newPosition = new Vector3(0, 0, 0);
        door.transform.DOLocalMove(newPosition, durationOfMove);
        door.transform.DOLocalRotate(newRotation, durationOfMove);
        yield return new WaitForSeconds(1f);
    }
}
