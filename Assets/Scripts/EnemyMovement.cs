using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{

    private float originalX;
    private float maxOffset = 5.0f;
    private float enemyPatroltime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D enemyBody;
    public Animator enemyAnimator;
    public AudioSource goombaAudio;
    public UnityEvent onIncrementScore;

    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
    }
    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * maxOffset / enemyPatroltime, 0);
    }
    void Movegoomba()
    {
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }

    // note that this is Update(), which still works but not ideal. See below.
    // void Update()
    // {

    // }

    void FixedUpdate()
    {
        if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
        {// move goomba
            Movegoomba();
        }
        else
        {
            // change direction
            moveRight *= -1;
            ComputeVelocity();
            Movegoomba();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "FireBall(Clone)")
        {
            EnemyDefeated();
            Destroy(other.gameObject);
        }

        if (other.gameObject.GetComponent<BuffStateController>())
        {
            BuffStateController buffStateController = other.gameObject.GetComponent<BuffStateController>();
            if (buffStateController.currentState.name == "Starman")
            {
                EnemyDefeated();
            }
        }
    }

    public void EnemyDefeated()
    {
        // disable collider
        GetComponent<Collider2D>().enabled = false;
        Debug.Log("Goomba defeated!");
        enemyAnimator.Play("goombaSquash");
        goombaAudio.Play();
        onIncrementScore.Invoke();

        velocity = Vector2.zero;
    }

    public void EnemyDefeatedComplete()
    {
        Debug.Log("Goomba defeated animation complete!");
        Destroy(gameObject);
    }
}