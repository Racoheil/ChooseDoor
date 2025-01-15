using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventService 
{
    public static event Action OnDoorClicked;
    public static void CallOnDoorClicked()
        =>OnDoorClicked?.Invoke();

    public static event Action OnRightAnswerSelected;
    public static void CallOnRightAnswerSelected()
        => OnRightAnswerSelected?.Invoke();

    public static event Action OnWrongAnswerSelected;
    public static void CallOnWrongAnswerSelected()
        => OnWrongAnswerSelected?.Invoke();
    
    public static event Action OnNextQuestionRun;
    public static void CallOnNextQuestionRun()
        => OnNextQuestionRun?.Invoke();

    public static event Action OnLevelWin;
    public static void CallOnLevelWin()
        => OnLevelWin?.Invoke();

    public static event Action OnLevelLose;
    public static void CallOnLevelLose()
        => OnLevelLose?.Invoke();

    public static event Action OnTakeDamage;
    public static void CallOnTakeDamage()
        => OnTakeDamage?.Invoke();
    
    public static event Action<float> OnBackpackOpen;
    public static void CallOnBackpackOpen(float animationTime)
        => OnBackpackOpen?.Invoke(animationTime); 
    
    public static event Action<float> OnBackpackClose;
    public static void CallOnBackpackClose(float animationTime)
        => OnBackpackClose?.Invoke(animationTime);


    /// <summary>
    /// SOUNDS
    /// </summary>
    public static event Action OnCollectionOpen;
    public static void CallOnCollectionOpen()
        => OnCollectionOpen?.Invoke();

    public static event Action OnCollectionClose;  
    public static void CallOnCollectionClose()
        => OnCollectionClose?.Invoke();

    public static event Action OnLevelSelect;
    public static void CallOnLevelSelect()
        => OnLevelSelect?.Invoke();

    public static event Action OnRightAnswerSound;
    public static void CallOnRightAnswerSound()
        => OnRightAnswerSound?.Invoke();

    public static event Action OnWrongAnswerSound;
    public static void CallOnWrongAnswerSound()
        => OnWrongAnswerSound?.Invoke();
    
    public static event Action OnTakeDamageSound;
    public static void CallOnTakeDamageSound()
        => OnTakeDamageSound?.Invoke();
    
    public static event Action OnRightAnswerHighlight;
    public static void CallOnRightAnswerHighlight()
        => OnRightAnswerHighlight?.Invoke(); 
    
    public static event Action OnTakeGift;
    public static void CallOnTakeGift()
        => OnTakeGift?.Invoke(); 
    
    public static event Action OnGoToMenu;
    public static void CallOnGoToMenu()
        => OnGoToMenu?.Invoke();
    
    public static event Action OnButtonClick;
    public static void CallOnButtonClick()
        => OnButtonClick?.Invoke();
}
