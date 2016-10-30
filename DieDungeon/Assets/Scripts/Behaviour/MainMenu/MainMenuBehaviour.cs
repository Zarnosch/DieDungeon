using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenuBehaviour : MonoBehaviour {


    public void OnGameStart()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnGameQuit()
    {
        if (Application.isEditor)
        {

        }
        else
        {
            Application.Quit();
        }
    }
}
