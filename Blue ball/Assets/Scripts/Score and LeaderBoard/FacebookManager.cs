using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class FacebookManager : MonoBehaviour {

    private static FacebookManager _instance;

    public static FacebookManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject fbm = new GameObject("FBManager");
                fbm.AddComponent<FacebookManager>();
            }
            return _instance;
        }
    }

    public bool IsLoggedIn { get; set; }
    public string ProfileName { get; set; }
    public Sprite ProfilePic { get; set; }
    public string AppLinkURL { get; set; }


    void Start()
    {
        //IsLoggedIn = false;
    }

    void Awake()
    {
       
        DontDestroyOnLoad(this.gameObject);
        _instance = this;


    }

    public void InitFB()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(SetInit, OnHideUnity);
        }
        else
        {
            IsLoggedIn = FB.IsLoggedIn;
        }
    }

    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("FB is logged in");
            GetProfile();
        }
        else
        {
            Debug.Log("FB is not logged in");
        }

        IsLoggedIn = FB.IsLoggedIn;
    }

    void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    
    public void GetProfile()
    {
        FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
        FB.API("me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);

    }


    void DisplayUsername(IResult result)
    {

        if (result.Error == null)
        {
            ProfileName = "" + result.ResultDictionary["first_name"];
        }
        else
        {
            Debug.Log(result.Error);
        }

    }

    void DisplayProfilePic(IGraphResult result)
    {
        if (result.Texture != null)
        {
            ProfilePic = Sprite.Create(result.Texture, new Rect(0, 0, 128, 128), new Vector2());
        }
    }

    public void Share()
    {
        FB.FeedShare(
            string.Empty,
            new Uri("https://apps.facebook.com/mazetrials"),
            "Maze Trial!",
            "I scored " + PlayerPrefs.GetInt("CurrentScore") +" in Maze Trials. Beat that!",
            "Check out this game",
            new Uri("http://postimg.org/image/8kgv927nz/"),
            string.Empty,
            ShareCallback
            );
    }

    void ShareCallback(IResult result)
    {
        if (result.Cancelled)
        {
            Debug.Log("Share Cancelled");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Error on share!");
        }
        else if (!string.IsNullOrEmpty(result.RawResult))
        {
            Debug.Log("Success on share");
        }
    }

    public void Invite()
    {
        FB.Mobile.AppInvite(
        new Uri("https://apps.facebook.com/mazetrial"),
        new Uri("http://postimg.org/image/8kgv927nz/"),
        InviteCallback);
    }

    void InviteCallback(IResult result)
    {
        if (result.Cancelled)
        {
            Debug.Log("Invite Cancelled");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Error on invite!");
        }
        else if (!string.IsNullOrEmpty(result.RawResult))
        {
            Debug.Log("Success on invite");
        }
    }

    public void ShareWithUsers()
    {
        FB.AppRequest(
            "Come and join me, I bet you can't beat my score!",
            null,
            new List<object>() { "app_users"},
            null,
            null,
            null,
            null,
            ShareWithUsersCallback
            );
    }

    void ShareWithUsersCallback(IAppRequestResult result)
    {
        if (result.Cancelled)
        {
            Debug.Log("Challenge Cancelled");
        }
        else if (!string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("Error on challenge!");
        }
        else if (!string.IsNullOrEmpty(result.RawResult))
        {
            Debug.Log("Success on challenge");
        }
    }
}
