using UnityEngine;
using System.Collections;

public class HighScores : MonoBehaviour {

    const string privateCode = "5Fw7xAYmskSq4Z_zaIRFvw-b1GJFiwsk-pbaNzHvYB0w";
    const string publicCode = "56e597c66e51b617d8c0b020";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    static HighScores instance;
    DisplayHighScores highscoresDisplay;

    void Awake()
    {
        instance = this;
        highscoresDisplay = GetComponent<DisplayHighScores>();
    }

    public static void AddNewHighScore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
            DownloadHighScores();
        }
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighScores()
    {
        StartCoroutine("DownloadNewHighscoreFromDatabase");
    }

    IEnumerator DownloadNewHighscoreFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighScores(www.text);
            highscoresDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Error downloading: " + www.error);
        }
    }

    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            print(highscoresList[i].username + ": " + highscoresList[i].score);
        }
    }

    
}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
