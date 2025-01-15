
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefsSaveService : ISaveService
{
   public bool[] _giftsStates;

   public int[] _levelStates;
   private enum LevelState { Closed = 0, Open = 1, Completed = 2 }

   private int _allGiftsCount = 100;

   private int _openedGiftsCount;

   private static string _giftCollectionKey = "CloseOpenGiftStates";

   private static string _levelsStatesKey = "LevelsStatesArray";
    
   private void Awake()
   {
        _giftsStates = new bool[_allGiftsCount];
   }

    public int GetAllGiftsCount()
    {

        return _allGiftsCount;
    }
        

   public void SetAllGiftsCount(int value)
   {
        if (PlayerPrefs.HasKey(_giftCollectionKey)==false)
        {
            _allGiftsCount = value;
            _giftsStates = new bool[_allGiftsCount];
            SaveCollectedGifts(_giftsStates);
        }
    }
   
   public void SaveCollectedGift(int giftId)
   {
        _giftsStates = LoadCollectedGifts();
        _giftsStates[giftId] = true;
        SaveCollectedGifts(_giftsStates);
        
   }

   public bool[] LoadCollectedGifts()
   {

        string boolArrayString = PlayerPrefs.GetString(_giftCollectionKey);
        string[] boolArrayStrings = boolArrayString.Split(',');

        bool[] boolArray = new bool[boolArrayStrings.Length];

        for (int i = 0; i < boolArrayStrings.Length; i++)
        {
            boolArray[i] = boolArrayStrings[i] == "1";
        }
        return boolArray;
   }

    public void SaveCollectedGifts(bool[] boolArray)
    {
        string boolArrayString = "";

        for (int i = 0; i < boolArray.Length; i++)
        {
            boolArrayString += boolArray[i] ? "1" : "0"; // Преобразование в 1 или 0
            if (i < boolArray.Length - 1)
            {
                boolArrayString += ",";
            }
        }
        PlayerPrefs.SetString(_giftCollectionKey, boolArrayString);
        PlayerPrefs.Save();
    }

    public void SaveCompletedLevel(int levelId)
    {
        int[] levelsStatesArray = GetAllLevelsStates();

        //Указываем уровень как пройденный и открываем следующий уровень
        int numberOfLevels = LevelsStatesService.instance.GetNumberOfLevels();
        levelsStatesArray[levelId] = (int)(LevelState.Completed);
        Debug.Log("levelId = " + levelId + "numberOfLevels =" + numberOfLevels);
        
        if (levelId+1 != numberOfLevels&& levelsStatesArray[levelId + 1]!=(int)(LevelState.Completed)) 
        {
            levelsStatesArray[levelId + 1] = (int)(LevelState.Open);
        }
        
        string intArrayString = string.Join(",", levelsStatesArray.Select(i => i.ToString()).ToArray());

        PlayerPrefs.SetString(_levelsStatesKey, intArrayString);
        PlayerPrefs.Save();
    }

    public void SaveLevelsStates(int[] levelsStatesInt)
    {
     

        // Преобразуем массив в строку
        string intArrayString = string.Join(",", levelsStatesInt.Select(i => i.ToString()).ToArray());

        // Сохраняем строку в PlayerPrefs
        PlayerPrefs.SetString(_levelsStatesKey, intArrayString);

        // Сохраняем PlayerPrefs
        PlayerPrefs.Save();
    }
    public int[] GetAllLevelsStates()
    {
        string intArrayString = PlayerPrefs.GetString(_levelsStatesKey);
       
        string[] intStrings = intArrayString.Split(",");
       
        int[] levelsStatesIntArray = new int[intStrings.Length];
       
        for (int i = 0; i < intStrings.Length; i++)
        {
            levelsStatesIntArray[i] = int.Parse(intStrings[i]);
        }
       
        return levelsStatesIntArray;
    }

    public string GetLevelsStatesArrayKey()
    {
        return _levelsStatesKey;
    }
}
