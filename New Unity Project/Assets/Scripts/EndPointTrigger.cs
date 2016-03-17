using UnityEngine;
using System.Collections;

public class EndPointTrigger : MonoBehaviour {
    private bool playerInZone;
   

	// Use this for initialization
	void Start () {
        playerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (playerInZone)
        {
           //Application.LoadLevel(levelToLoad);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
         
            TimerManager.timerStop = false;
            playerInZone = true;
            GameManager.ReachedEndPoint();
            other.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            playerInZone = false;
            TimerManager.timerStop = true;
        }
    }

}
