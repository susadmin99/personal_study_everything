using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    int score = 0;
    int highScore = 0;

    public Text currentScoreTxt;
    public Text highScoreTxt;


    private void Start()
    {
        LoadScore();    
    }

    private void Update()
    {
        CalculateScore();
        ShowScore();
    }

    void CalculateScore()
    {
        score = Snake.instance.tail.Count;
    }

    void ShowScore()
    {
        currentScoreTxt.text = score.ToString();
        highScoreTxt.text = highScore.ToString();
    }

    public void SaveScore()
    {
        SaveHighScore sh = new SaveHighScore(CheckIfNewHighScore());

        Save.SaveToFile(sh, "HighScore");
    }

    void LoadScore()
    {
        SaveHighScore sh = new SaveHighScore();
        Save.LoadFromFile(sh, "HighScore");
        highScore = sh.highScore;
    }

    int CheckIfNewHighScore()
    {
        if (score > highScore)
            return score;
        else
            return highScore;
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveScore();
        }
    }

    private void OnApplicationQuit()
    {
        SaveScore();
    }
}

[System.Serializable]
public class SaveHighScore
{
    public int highScore = 0;

    public SaveHighScore(int highScore)
    {
        this.highScore = highScore;
    }

    public SaveHighScore()
    {
    }
}

