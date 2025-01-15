using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveService
{
    public void SaveCollectedGift(int giftId);

    public void SaveCollectedGifts(bool[] boolArray);

    public bool[] LoadCollectedGifts();

    public void SetAllGiftsCount(int value);

    public int GetAllGiftsCount();

    public void SaveCompletedLevel(int levelId);

    public int[] GetAllLevelsStates();
    
    public string GetLevelsStatesArrayKey();

    public void SaveLevelsStates(int[] levelsStatesInt);
}
