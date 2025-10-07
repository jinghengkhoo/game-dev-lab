using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioFeet : MonoBehaviour
{
    public Rigidbody2D marioBody;
    public PlayerMovement playerMovement;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (playerMovement.alive)
            {
                Debug.Log("Enemy hit!");
                marioBody.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                other.gameObject.GetComponent<EnemyMovement>().EnemyDefeated();
            }

        }
    }
}
