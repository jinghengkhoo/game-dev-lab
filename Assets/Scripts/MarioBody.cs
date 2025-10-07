using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarioBody : MonoBehaviour
{
    public Rigidbody2D marioBody;
    public Animator marioAnimator;
    public AudioSource marioDeath;
    public PlayerMovement playerMovement;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with goomba!");
            playerMovement.OnDie();
        }
    }
}
