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
	    
	}

    public void TakeLive()
    {
        if (lives > 0)
        {
            lives--;
            hearts[lives].color = new Color(0, 0, 0);
        }
    }
}
