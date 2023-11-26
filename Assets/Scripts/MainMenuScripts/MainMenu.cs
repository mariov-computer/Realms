using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   //public int optionsMenuSceneIndex = 2;

    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnOptionsButton()
    {
        //SceneManager.LoadScene(optionsMenuSceneIndex);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
