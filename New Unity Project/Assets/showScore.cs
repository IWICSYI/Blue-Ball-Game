using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showScore : MonoBehaviour {


    Text text;
    public static int score;
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
}
