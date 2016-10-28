using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MainMenuBehaviour : MonoBehaviour {


    public void OnGameStart()
    {
        //Application.LoadLevel();
    }

    public void OnGameQuit()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
