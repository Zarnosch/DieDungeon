using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {

    public int lives;
    public Image[] hearts;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    if(PlayerHandlerBehaviour.Instance.activePlayer.PlayerData.Health != lives)
        {
            lives = PlayerHandlerBehaviour.Instance.activePlayer.PlayerData.Health;
            UpdateLives();
        }
	}

    public void UpdateLives()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < lives)
            {
                hearts[i].color = new Color(255, 255, 255);
            }
            else
            {
                hearts[i].color = new Color(0, 0, 0);
            }
        }
    }
}
