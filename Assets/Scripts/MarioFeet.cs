using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioFeet : MonoBehaviour
{
    public Rigidbody2D marioBody;
    public PlayerMovement playerMovement;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && playerMovement.alive)
        {
            float marioFeetY = transform.position.y;
            float enemyTopY = other.bounds.center.y + (other.bounds.extents.y * 0.3f);

            if (marioFeetY > enemyTopY)
            {
                Debug.Log("Enemy stomped!");
                marioBody.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
                other.gameObject.GetComponent<EnemyMovement>().EnemyDefeated();
            }
        }
    }
}
