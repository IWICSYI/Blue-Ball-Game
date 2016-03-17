using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static int endPointReached=0;
    public string levelToLoad;
    public int endPointNeeded;
    
    void Start()
    {
        endPointReached = 0;
      

    }
	// Update is called once per frame
	void Update () {
        if (endPointReached == endPointNeeded)
        {
            SceneManager.LoadSceneAsync(levelToLoad);
        }

	}

    public static void ReachedEndPoint()
    {
        endPointReached += 1;
       
    }

    public static void ResetScore()
    {
        endPointReached = 0;
    }
}
