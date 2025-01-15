using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuButton : MonoBehaviour
{
    public void GoToMenu()
    {
       StartCoroutine(GoToMenuRoutine());
    }

    IEnumerator GoToMenuRoutine()
    {
        EventService.CallOnGoToMenu();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
