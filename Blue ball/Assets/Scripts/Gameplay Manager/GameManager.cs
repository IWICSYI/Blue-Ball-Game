using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static int endPointReached=0;
    public string levelToLoad;
    public int endPointNeeded;
   
    public int count = 0;

    void Start()
    {
        endPointReached = 0;
        count = 0;
        TimerManager.playerStartMoving = false;
       // TimerManager.timerStop = false;




    }
	// Update is called once per frame
	void Update () {
        if (endPointReached == endPointNeeded)
        {
            TimerManager.timerStop = false;
           
            Invoke("ChangeLevel", 0.02f);
           
        }

	}

    public static void ReachedEndPoint()
    {
        endPointReached += 1;
       
    }

    public void ChangeLevel()
    {
        SceneManager.LoadSceneAsync(levelToLoad);
    }
    public static void ResetScore()
    {
        endPointReached = 0;
    }
}
