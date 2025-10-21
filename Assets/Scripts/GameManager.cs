using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    // events
    public IntVariable gameScore;
    public UnityEvent onUpdateScore;

    // private int score = 0;

    void Start()
    {
        // SceneManager.activeSceneChanged += SceneSetup;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        Time.timeScale = 1.0f;
        gameScore.Value = 0;
        onUpdateScore.Invoke();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("0");
        gameScore.Value = 0;
        Time.timeScale = 1.0f;
    }

    public void IncreaseScore(int increment)
    {
        Debug.Log("Increasing score by " + increment);
        gameScore.ApplyChange(increment);
        Debug.Log("Score: " + gameScore.Value);
        onUpdateScore.Invoke();
    }

    // public void SceneSetup(Scene current, Scene next)
    // {
    //     SetScore(gameScore.Value);
    // }
}