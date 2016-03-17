using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;
    Text text;
	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();
        score = PlayerPrefs.GetInt("CurrentScore");

	}
	
	// Update is called once per frame
	void Update () {
        if (score < 0)
        {
            score = 0;
        }
        text.text = score.ToString();

	}

    public static void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        PlayerPrefs.SetInt("CurrentScore", score);
    }

    public static void ResetScore()
    {
        score = 0;
    }
}
