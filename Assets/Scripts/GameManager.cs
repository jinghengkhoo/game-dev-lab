using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : Singleton<GameManager>
{
    // events
    public UnityEvent gameStart;
    public UnityEvent gameRestart;
    public UnityEvent<int> scoreChange;
    public UnityEvent gameOver;
    public IntVariable gameScore;

    // private int score = 0;

    void Start()
    {
        gameStart.Invoke();
        Time.timeScale = 1.0f;
        SceneManager.activeSceneChanged += SceneSetup;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameRestart()
    {
        gameStart.Invoke();
        SceneManager.LoadScene("0");
        gameScore.Value = 0;
        Time.timeScale = 1.0f;
    }

    public void IncreaseScore(int increment)
    {
        Debug.Log("Increasing score by " + increment);
        gameScore.ApplyChange(increment);
        Debug.Log("Score: " + gameScore.Value);
        SetScore(gameScore.Value);
    }

    public void SetScore(int score)
    {
        scoreChange.Invoke(score);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOver.Invoke();
    }

    public void SceneSetup(Scene current, Scene next)
    {
        // gameStart.Invoke();
        SetScore(gameScore.Value);
    }
}