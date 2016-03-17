using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    
    public float speed;
    private Rigidbody2D rb2d;
   
   
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        int horizontal = (int)(Input.GetAxisRaw("Horizontal"));

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
       int vertical = (int)(Input.GetAxisRaw("Vertical"));

        
        rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 1.8f),
                                     Mathf.Lerp(0, Input.GetAxis("Vertical") * speed, 1.8f));
        if (horizontal != 0 || vertical != 0)
            TimerManager.playerStartMoving = true;


        #if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
            rb2d.velocity = new Vector2(Mathf.Lerp(0, CnControls.CnInputManager.GetAxis("Horizontal") * speed, 1.8f),
                                            Mathf.Lerp(0, CnControls.CnInputManager.GetAxis("Vertical") * speed, 1.8f));


        #endif

    }
}
