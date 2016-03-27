using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour {

 
    public float timeLeft = 50.0f;
    public int scoreToAdd = 100;
    
   // public static float finalTimeLeft;
    private Text timerText;
    public static bool playerStartMoving = false;
    public static bool timerStop = true;

    private int count = 0;
    
	// Use this for initialization
	void Start () {
        timerText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	


    public void Update( )
    {
        if(playerStartMoving&& timerStop)
         timeLeft -= Time.deltaTime;
        // timerText.text = "Timer:" + timeLeft.ToString();
        if (!timerStop)
        {
            ScoreManager.AddScore((int)timeLeft * scoreToAdd);
            timerStop = true;

        }

        if (timeLeft <= 0.0f)
        {
            // End the level here.
            timerText.text = "You ran out of time";
            ScoreManager.ResetScore();
            PlayerPrefs.SetInt("CurrentScore", ScoreManager.score);
            if (count == 0) { 
               PlayerController.isExplode = true;
                count = count + 1;
            }

        }
        else
        {
            timerText.text = "Time left = " + (int)timeLeft + " seconds";
        }

    }

   
}
