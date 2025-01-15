using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundServiceGame : MonoBehaviour
{
    [SerializeField]
    private AudioSource _openDoor;

    [SerializeField]
    private AudioSource _closeDoor;

    [SerializeField]
    private AudioSource _rightAnswer;

    [SerializeField]
    private AudioSource _wrongAnswer;

    [SerializeField] 
    private AudioSource _takeDamage;

    [SerializeField] 
    private AudioSource _takeGiftSound;
    
    [SerializeField]
    private AudioSource _levelWin;  
    
    [SerializeField]
    private AudioSource _levelLose;

    [SerializeField]
    private AudioSource _click;

    private void OnEnable()
    {
        EventService.OnDoorClicked += PlayDoorOpen;
        EventService.OnRightAnswerSound += PlayRightAnswer;
        EventService.OnWrongAnswerSound += PlayWrongAnswer;
        EventService.OnTakeDamageSound += PlayTakeDamage;
        EventService.OnTakeGift += PlayTakeGift;
        EventService.OnLevelWin += PlayLevelWin;
        EventService.OnLevelLose += PlayLevelLose;
        EventService.OnGoToMenu += PlayClick;
    }

    private void OnDisable()
    {
        EventService.OnDoorClicked -= PlayDoorOpen;
        EventService.OnRightAnswerSound -= PlayRightAnswer;
        EventService.OnWrongAnswerSound -= PlayWrongAnswer;
        EventService.OnTakeDamageSound -= PlayTakeDamage;
        EventService.OnTakeGift -= PlayTakeGift;
        EventService.OnLevelWin -= PlayLevelWin;
        EventService.OnLevelLose -= PlayLevelLose;
        EventService.OnGoToMenu -= PlayClick;
    }

    private void PlayDoorOpen()
    {
        _openDoor.Play();
    }

    private void PlayRightAnswer()
    {
        _rightAnswer.Play();
    } 

    private void PlayWrongAnswer()
    {
        _wrongAnswer.Play();
    }

    private void PlayTakeDamage()
    {
        _takeDamage.Play();
    }

    private void PlayTakeGift()
    {
        _takeGiftSound.Play();
    }

    private void PlayLevelWin()
    {
        _levelWin.Play();
    }

    private void PlayLevelLose()
    {
        _levelLose.Play();
    }
    
    private void PlayClick()
    {
        _click.Play();
    }
}
