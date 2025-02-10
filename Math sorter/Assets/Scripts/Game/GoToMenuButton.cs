using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GoToMenuButton : MonoBehaviour
{
    public void GoToMenu()
    {
       StartCoroutine(GoToMenuRoutine());
    }

    IEnumerator GoToMenuRoutine()
    {
        EventService.CallOnGoToMenu();
        yield return new WaitForSeconds(0.0f);
        YandexGame.FullscreenShow();

        
        
        SceneManager.LoadScene("MainMenu");
    }
}
