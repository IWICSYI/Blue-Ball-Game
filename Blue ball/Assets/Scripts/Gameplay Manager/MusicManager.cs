using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

    private static MusicManager _instance;
    void Start()
    {

        if (!_instance)
            _instance = this;
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);


        DontDestroyOnLoad(this.gameObject);
    }
}

