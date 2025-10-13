using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToMainMenuButton : MonoBehaviour
{
    public void ReturnToMain()
    {
        Debug.Log("Onclick back to main menu button");
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
