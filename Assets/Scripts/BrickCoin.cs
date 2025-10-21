using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BrickCoin : MonoBehaviour
{
    [System.NonSerialized]
    public bool alive = true;

    public Animator brickAnimator;
    public Animator coinAnimator;
    public UnityEvent onIncrementScore;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            brickAnimator.Play("hit");
            if (alive)
            {
                alive = false;
                coinAnimator.Play("coin");
                Debug.Log("Coin collected!");

                onIncrementScore.Invoke();
            }
        }

    }
}
