using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// later on, teach interface
public class RestartButtonController : MonoBehaviour, IInteractiveButton
{
    // implements the interface
    public UnityEvent gameRestart;
    public void ButtonClick()
    {
        Debug.Log("Onclick restart button");
        gameRestart.Invoke();
    }
}
