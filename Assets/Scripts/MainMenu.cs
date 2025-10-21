using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    public GameObject highScoreText;

    public IntVariable gameScore;
    public UnityEvent onStartGame;

    void Start()
    {
        SetHighscore();
    }

    public void GoToLoadScene()
    {
        Debug.Log("Loading scene...");
        onStartGame.Invoke();
        SceneManager.LoadSceneAsync("LoadingScene", LoadSceneMode.Single);
    }

    void SetHighscore()
    {
        highScoreText.GetComponent<TextMeshProUGUI>().text = "TOP- " + gameScore.previousHighestValue.ToString("D6");
    }

    public void ResetHighscore()
    {
        GameObject eventSystem = GameObject.Find("EventSystem");
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        gameScore.ResetHighestValue();
        SetHighscore();
    }
}