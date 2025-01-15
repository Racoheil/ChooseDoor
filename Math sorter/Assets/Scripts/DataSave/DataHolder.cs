using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder
{
    private static int _selectedLevel;

    private static bool isFirstOpen = true;

    private static bool isMusicPlaying = true;

    public static void SetSelectedLevel(int selectedLevel)
    {
        _selectedLevel = selectedLevel; 
    }

    public static int GetSelectedLevel()
    {
        return _selectedLevel;
    }

    public static void SetFirstOpenState(bool state)
    {
        isFirstOpen = state;
    } 
    public static bool GetFirstOpenState()
    {
        return isFirstOpen;
    }

    public static void SetMusicState(bool state)
    {
        isMusicPlaying = state;
    }
    public static bool GetMusicState()
    {
        return isMusicPlaying;
    }

}
