using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject mainPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;
    void Awake()
    {
        GameManager.instance.gameStart.AddListener(GameStart);
        GameManager.instance.gameRestart.AddListener(GameStart);
        GameManager.instance.scoreChange.AddListener(SetScore);
        GameManager.instance.gameOver.AddListener(GameOver);
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
        Time.timeScale = 0.0f;
        mainPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void SetScore(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        gameOverScoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }


    public void GameOver()
    {
        // stop time
        Time.timeScale = 0.0f;
        mainPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}
