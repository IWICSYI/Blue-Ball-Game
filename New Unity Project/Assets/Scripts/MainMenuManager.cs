using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public string startLevel;

    public void NewGame()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        Application.LoadLevel(startLevel);
    }

	
}
