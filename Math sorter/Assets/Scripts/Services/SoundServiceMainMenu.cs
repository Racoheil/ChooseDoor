using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundServiceMainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource _openCollection;

    [SerializeField]
    private AudioSource _closeCollection;

    [SerializeField]
    private AudioSource _click;
    private void OnEnable()
    {
        EventService.OnCollectionOpen += PlayCollectionOpenSound;
        EventService.OnCollectionClose += PlayCollectionCloseSound;
        EventService.OnLevelSelect += PlayClick;
        EventService.OnButtonClick += PlayClick;
    }
    private void OnDisable()
    {
        EventService.OnCollectionOpen -= PlayCollectionOpenSound;
        EventService.OnCollectionClose -= PlayCollectionCloseSound;
        EventService.OnLevelSelect -= PlayClick;
        EventService.OnButtonClick -= PlayClick;
    }
    private void PlayCollectionOpenSound()
    {
        _openCollection.Play();
    }
    private void PlayCollectionCloseSound()
    {
        _closeCollection.Play();
    }

    private void PlayClick()
    {
        _click.Play();  
    }

}
