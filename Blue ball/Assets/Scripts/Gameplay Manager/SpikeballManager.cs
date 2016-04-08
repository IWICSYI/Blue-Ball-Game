using UnityEngine;
using System.Collections;

public class SpikeballManager : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {

            PlayerController.isExplode = true;

        }
    }
}
