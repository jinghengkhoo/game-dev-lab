using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class HUDManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject mainPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    public GameObject highscoreText;
    public IntVariable gameScore;
    void Awake()
    {
        SetScore(gameScore.Value);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        Time.timeScale = 1.0f;
        mainPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void OnScoreUpdate()
    {
        SetScore(gameScore.Value);
    }

    public void SetScore(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        gameOverScoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }


    public void GameOver()
    {
        Debug.Log("Game Over in HUDManager");
        // stop time
        Time.timeScale = 0.0f;
        mainPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        // set highscore
        highscoreText.GetComponent<TextMeshProUGUI>().text = "TOP- " + gameScore.previousHighestValue.ToString("D6");
        // show
        highscoreText.SetActive(true);
    }
}
