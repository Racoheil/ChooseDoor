using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftsCollectionManager : MonoBehaviour
{
    [SerializeField]
    private GraphicsConfig[] _positiveGiftsItems;

    [SerializeField]
    private Image[] _giftHolders;


    [SerializeField]
    private ISaveService _prefsSaveService;

    [SerializeField] private Color _lockGiftColor;
  
   
    private void Awake()
    {
        


    }
    private void Start()
    {
        _prefsSaveService = new PrefsSaveService();
         SetGiftsCount();
         LoadAllGifts();
    }
    private void SetGiftsCount()
    {
        int giftsCount=0;
        for (int j = 0; j < _positiveGiftsItems.Length; j++)
        {
            for (int i = 0; i < _positiveGiftsItems[j].Graphics.Count; i++)
            {
                giftsCount++;
             //   print(giftsCount+" giftscount");
            }
        }
        _prefsSaveService.SetAllGiftsCount(giftsCount);
    }

    public void LoadAllGifts()
    {
        bool[] giftsStates = _prefsSaveService.LoadCollectedGifts();
        foreach(bool val  in giftsStates)
        {
            //Debug.Log(val);
        }
        for (int j = 0;j< _positiveGiftsItems.Length;j++)
        {
            for (int i = 0; i< _positiveGiftsItems[j].Graphics.Count; i++)
            {
                int addingValue = _positiveGiftsItems[j].Graphics.Count;
                int multiplyValue = j;
                int giftId = (addingValue*multiplyValue)+i;
                //Debug.Log("GiftID of giftHolder = " + giftId);
               
                
                
               
                if (giftsStates[giftId] == true)
                {
                    _giftHolders[giftId].sprite = _positiveGiftsItems[j].Graphics[i];
                }
                else if (giftsStates[giftId] ==false)
                {
                    _giftHolders[giftId].sprite = _positiveGiftsItems[j].Graphics[i];
                    _giftHolders[giftId].color = _lockGiftColor;
                }
            }
        }

       
    }
    public void LoadAllGiftsStates()
    {
        bool[] array = _prefsSaveService.LoadCollectedGifts();
        for(int i=0;i<20;i++)
        {
          //  Debug.Log("state of gift" + i + "=" + array[i]);
        }
    }
}
