﻿using UnityEngine;
using System.Collections;

public class CoinScore : MonoBehaviour {
   
    private AudioSource source;
    public int scoreForCoins;
    // Use this for initialization
    
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
       

        if (other.CompareTag("Player"))
        {
            GameObject soundEffect= GameObject.Find("SoundEffect");
            if (soundEffect != null)
            {
                source = soundEffect.GetComponent<AudioSource>();
                source.Play();
            }
            else {
                source = GetComponent<AudioSource>();
                source.Play();
            }


                ScoreManager.AddScore(scoreForCoins);
             Destroy(gameObject,0.15f);

        }
    }

   

}
