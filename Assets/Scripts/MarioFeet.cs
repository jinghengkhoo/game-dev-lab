using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioFeet : MonoBehaviour
{
    public Rigidbody2D marioBody;
    public PlayerMovement playerMovement;
    public MarioStateController marioStateController;

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

    public void BigMario()
    {
        Vector3 pos = transform.localPosition;
        pos.y = -0.49f;
        transform.localPosition = pos;
    }

    public void SmallMario()
    {
        Vector3 pos = transform.localPosition;
        pos.y = 0f;
        transform.localPosition = pos;
    }
}
