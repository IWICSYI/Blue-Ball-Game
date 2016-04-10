using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public string startLevel;
    public string leaderBoard;
    public string mainMenu;


    void Start()
    {
        GameObject edMusic = GameObject.Find("EDMUSIC");
        Destroy(edMusic);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        Application.LoadLevel(startLevel);
    }


    public void MainMenu()
    {
        PlayerPrefs.SetInt("CurrentScore", 0);
        Application.LoadLevel(mainMenu);
    }


    public void LeaderBoard()
    {
       
        Application.LoadLevel(leaderBoard);
    }

    public void Share()
    {

        Application.LoadLevel("Share");
    }

    public void Ending()
    {

        Application.LoadLevel("Ending");
    }


}
