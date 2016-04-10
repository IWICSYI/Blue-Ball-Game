using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    
    public float speed;
    private Rigidbody2D rb2d;
    private int count = 0;

    private AudioSource source;
    public AudioClip explodeSound;
    public  Animation explodeAnimation;
    public static bool isExplode;
    public Animator die;
    private float explodeTime =2f;
    private bool triggerEnd = false;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
      //  explode = GetComponent<Animation>();
        die = GetComponent<Animator>();
       // die.SetBool("Explode", false);
        isExplode = false;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
       int horizontal = (int)(Input.GetAxisRaw("Horizontal"));
       int vertical = (int)(Input.GetAxisRaw("Vertical"));

        
        rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 1.8f),
                                     Mathf.Lerp(0, Input.GetAxis("Vertical") * speed, 1.8f));

        if (horizontal != 0 || vertical != 0)
            TimerManager.playerStartMoving = true;


#if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
      rb2d.velocity = new Vector2(Mathf.Lerp(0, CnControls.CnInputManager.GetAxis("Horizontal") * speed, 1.8f),
                                                    Mathf.Lerp(0, CnControls.CnInputManager.GetAxis("Vertical") * speed, 1.8f));
        int  horizontalTouch = (int)(CnControls.CnInputManager.GetAxis("Horizontal"));
        int verticalTouch = (int)(CnControls.CnInputManager.GetAxis("Vertical"));
        if (horizontalTouch != 0 || verticalTouch != 0|| rb2d.velocity!=Vector2.zero)
            TimerManager.playerStartMoving = true;

#endif
        if (isExplode == true)
        {
            PlayerExplode();
            //isExplode = false;
            
            triggerEnd = true;
           
        }

        if (triggerEnd)
        {
            explodeTime -= Time.deltaTime;
            rb2d.velocity = Vector3.zero;

            if (explodeTime <= 0)
            {
                
                Application.LoadLevel(Application.loadedLevel);
            }
        }


    }

    void PlayerExplode()
    {
        if (isExplode == true)
        {
            if (count == 0)
            {
                source = GetComponent<AudioSource>();
                source.clip = explodeSound;
                source.Play();
                count = count + 1;
               

            }
            // explode.Play("PlayerExplode");
            die.enabled = true;
            die.SetBool("Explode", true);
            
            

        }
    }

}
