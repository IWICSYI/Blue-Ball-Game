using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;
    public static int initialscore;
    
    Text text;
	// Use this for initialization
	void Start () {

        text = GetComponent<Text>();
        score = PlayerPrefs.GetInt("CurrentScore");
        PlayerPrefs.SetInt("StageStartScore", score);
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

    public static void ReduceScore(int pointsToDeduct)
    {
        score -= pointsToDeduct;
        PlayerPrefs.SetInt("CurrentScore", score);
        PlayerPrefs.SetInt("StageStartScore", score);
    }

    public static void ResetScore()
    {
        score = PlayerPrefs.GetInt("StageStartScore");
    }
}
