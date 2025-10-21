using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarioBody : MonoBehaviour
{
    public MarioStateController marioStateController;
    public BuffStateController buffStateController;
    private BoxCollider2D boxCollider;
    void Awake()
    {
        // Get the BoxCollider2D component attached to this GameObject
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (buffStateController.currentState.name == "Starman")
            {
                // Do nothing, Mario is invincible
                return;
            }
            marioStateController.SetPowerup(PowerupType.Damage);
        }
    }

    public void BigMario()
    {
        boxCollider.size = new Vector2(0.9928019f, 1.809089f);
        boxCollider.offset = new Vector2(-0.001776874f, 0.09628454f);
    }

    public void SmallMario()
    {
        boxCollider.size = new Vector2(0.8191223f, 0.8154321f);
        boxCollider.offset = new Vector2(0.001846313f, 0.09228393f);
    }
}
