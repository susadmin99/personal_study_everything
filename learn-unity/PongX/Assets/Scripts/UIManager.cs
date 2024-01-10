using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class UIManager : MonoBehaviour
{
    public enum Sides
    {
        Left,
        Right
    }

    public static UIManager Instance { get; private set; }

    [SerializeField] GameObject scoreTxt;
    [SerializeField] Text leftScoreText;
    [SerializeField] Text rightScoreText;

    int leftScore = 0;
    int rightScore = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadScore();
        UpdateScoreText();
    }

    public void GoalScored(Sides side)
    {
        switch(side)
        {
            case Sides.Left:
                leftScore++;
                scoreTxt.SetActive(true);
                break;

            case Sides.Right:
                rightScore++;
                scoreTxt.SetActive(true);
                break;

            default:
                break;
        }

        UpdateScoreText();
    }

    public void ContinueGame()
    {
        SaveScore();
        scoreTxt.SetActive(false);
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    void UpdateScoreText()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    void SaveScore()
    {
        ScoreSave scoreSave = new ScoreSave();
        scoreSave.LeftScore = leftScore;
        scoreSave.RightScore = rightScore;
        string save = JsonUtility.ToJson(scoreSave);

        File.WriteAllText(Application.persistentDataPath+"/saveScore.json", save);
    }

    void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath+"/saveScore.json"))
        {
            string load = File.ReadAllText(Application.persistentDataPath+"/saveScore.json");
            ScoreSave scoreLoad = JsonUtility.FromJson<ScoreSave>(load);
            leftScore = scoreLoad.LeftScore;
            rightScore = scoreLoad.RightScore;
        }
    }
}

[System.Serializable]
class ScoreSave
{
    public int LeftScore = new int();
    public int RightScore = new int();

}
