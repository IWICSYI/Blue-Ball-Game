using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

 
    public float timeLeft = 50.0f;
    public int scoreToAdd = 1000;
    
   // public static float finalTimeLeft;
    private Text timerText;
    public static bool playerStartMoving = false;
    public static bool timerStop = true;

    private int count = 0;
    private int scorecount = 0;

    // Use this for initialization
    void Start () {
        timerText = GetComponent<Text>();
        timerStop = true;
    }
	
	// Update is called once per frame
	


    public void Update( )
    {
        if(playerStartMoving&& timerStop)
         timeLeft -= Time.deltaTime;
        
        if (!timerStop)
        {
            if (scorecount == 0)
            {
                Debug.Log("timeleft=" + timeLeft);
                Debug.Log("scoreToAdd=" + (int)System.Math.Ceiling(timeLeft) * scoreToAdd);
                ScoreManager.AddScore((int)System.Math.Ceiling(timeLeft) * scoreToAdd);
                scorecount = scorecount + 1;
                timerStop = true;
            }
           

        }

        if (timeLeft <= 0.0f)
        {
            // End the level here.
            timerText.text = "You ran out of time";

            ScoreManager.ResetScore();
            PlayerPrefs.SetInt("CurrentScore", ScoreManager.score);
            if (count == 0) {
                ScoreManager.ReduceScore(100);
                PlayerPrefs.SetInt("CurrentScore", ScoreManager.score);
                PlayerController.isExplode = true;
                count = count + 1;
            }

        }
        else
        {
            timerText.text = "Time left = " + timeLeft.ToString("#.0") + " sec";
        }

    }

   
}
