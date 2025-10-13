using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockPowerUp : MonoBehaviour
{
    [System.NonSerialized]
    public bool alive = true;

    public Animator questionblockAnimator;
    public Animator powerupAnimator;

    public GameObject powerup;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with block!");
        if (alive && other.gameObject.CompareTag("Player"))
        {
            alive = false;
            powerup.SetActive(true);
            questionblockAnimator.Play("hit");
            powerupAnimator.Play("start");
        }

    }
}
