using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    public static int score;

    public void GetInput(string username)
    {
        score = PlayerPrefs.GetInt("CurrentScore");
        HighScores.AddNewHighScore(username, score);
    }
}
