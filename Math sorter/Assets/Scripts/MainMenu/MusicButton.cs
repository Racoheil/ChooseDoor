using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField] 
    private Sprite _musicOnSprite, _musicOffSprite;

    [SerializeField]
    private AudioSource _musicSource;

    private Button _button;

    //private bool _isPlaying;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ClickMusicButton);
        // EnableMusic();
        SetStateOfMusic();
       
    }

    public void SetStateOfMusic()
    {
        if (!DataHolder.GetMusicState())
        {
            DisableMusic();
        }
        else if (DataHolder.GetMusicState()) EnableMusic();
    }
    public void ClickMusicButton()
    {
        print("Произошёл клик!");
        if (DataHolder.GetMusicState())
        {
            DisableMusic();
        }
        else if (!DataHolder.GetMusicState())EnableMusic();
    }

    void EnableMusic()
    {
        _musicSource.enabled = true;
        //_isPlaying = true;
        _button.image.sprite = _musicOnSprite;
        DataHolder.SetMusicState(true);
    }

    void DisableMusic()
    {
        _musicSource.enabled = false;
      //  _isPlaying = false;
        _button.image.sprite= _musicOffSprite;
        DataHolder.SetMusicState(false);

    }
}
