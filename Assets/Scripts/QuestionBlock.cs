using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    [System.NonSerialized]
    public bool alive = true;

    public Animator questionblockAnimator;
    public Animator coinAnimator;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with block!");
        if (alive && other.gameObject.CompareTag("Player"))
        {
            alive = false;
            questionblockAnimator.Play("hit");
            coinAnimator.Play("coin");
        }
        
    }
}
