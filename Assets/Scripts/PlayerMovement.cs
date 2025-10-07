using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // global variables
    public float speed = 10;
    private Rigidbody2D marioBody;
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;

    public Animator marioAnimator;

    public float upSpeed = 10;
    private bool onGroundState = true;

    public AudioSource marioAudio;

    public AudioSource marioDeath;
    public float deathImpulse = 15;

    public MarioActions marioActions;

    public UnityEvent gameOver;

    // state
    [System.NonSerialized]
    public bool alive = true;

    void Awake()
    {
        // Cache components early
        marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();
        Application.targetFrameRate = 30;

        if (marioActions == null)
            marioActions = new MarioActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        marioActions.gameplay.Enable();
        marioActions.gameplay.jump.performed += OnJump;
        marioActions.gameplay.jumphold.performed += OnJumpHoldPerformed;
        marioActions.gameplay.move.started += OnMove;
        marioActions.gameplay.move.canceled += OnMove;
        marioActions.gameplay.click.started += OnClickAction;
        marioActions.gameplay.click.performed += OnClickAction;
        marioActions.gameplay.click.canceled += OnClickAction;
        marioActions.gameplay.point.performed += OnPointAction;

        marioAnimator.SetBool("onGround", onGroundState);
    }

    void OnDisable()
    {
        if (marioActions != null)
        {
            marioActions.gameplay.jump.performed -= OnJump;
            marioActions.gameplay.jumphold.performed -= OnJumpHoldPerformed;
            marioActions.gameplay.move.started -= OnMove;
            marioActions.gameplay.move.canceled -= OnMove;
            marioActions.gameplay.click.started -= OnClickAction;
            marioActions.gameplay.click.performed -= OnClickAction;
            marioActions.gameplay.click.canceled -= OnClickAction;
            marioActions.gameplay.point.performed -= OnPointAction;

            marioActions.gameplay.Disable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.linearVelocity.x));
    }


    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7);
    void OnCollisionEnter2D(Collision2D col)
    {
        if (((collisionLayerMask & (1 << col.transform.gameObject.layer)) > 0) & !onGroundState)
        {
            onGroundState = true;
            // update animator state
            marioAnimator.SetBool("onGround", onGroundState);
        }
    }

    public float maxSpeed = 20;
    private bool moving = false;

    // FixedUpdate may be called once per frame. See documentation for details.
    void FixedUpdate()
    {
        if (alive && moving)
        {
            Move(faceRightState == true ? 1 : -1);
        }
    }

    void Move(int value)
    {
        Vector2 movement = new Vector2(value, 0);
        // check if it doesn't go beyond maxSpeed
        if (marioBody.linearVelocity.magnitude < maxSpeed)
            marioBody.AddForce(movement * speed);
    }

    public void GameRestart()
    {
        // reset animation
        marioAnimator.SetTrigger("gameRestart");
        alive = true;
    }

    public void RestartButtonCallback(int input)
    {
        Debug.Log("Restart!");
        // resume time
        Time.timeScale = 1.0f;
    }

    void PlayJumpSound()
    {
        // play jump sound
        marioAudio.PlayOneShot(marioAudio.clip);
    }

    void PlayDeathImpulse()
    {
        marioBody.AddForce(Vector2.up * deathImpulse, ForceMode2D.Impulse);
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (onGroundState)
        {
            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
            marioAnimator.SetBool("onGround", onGroundState);
        }
    }

    void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!alive) return;
            float move = context.ReadValue<float>();
            moving = true;
            if (move > 0 && !faceRightState)
            {
                faceRightState = true;
                marioSprite.flipX = false;
                if (marioBody.linearVelocity.x < -0.1f)
                    marioAnimator.SetTrigger("onSkid");
            }
            else if (move < 0 && faceRightState)
            {
                faceRightState = false;
                marioSprite.flipX = true;
                if (marioBody.linearVelocity.x > 0.1f)
                    marioAnimator.SetTrigger("onSkid");
            }
        }
        if (context.canceled)
        {
            moving = false;
            marioBody.linearVelocity = Vector2.zero;
        }
    }

    void OnJumpHoldPerformed(InputAction.CallbackContext context)
    {
        if (!onGroundState)
        {
            marioBody.AddForce(Vector2.up * upSpeed * 0.1f, ForceMode2D.Impulse);
        }
    }

    public void OnClickAction(InputAction.CallbackContext context)
    {
        if (context.started)
            Debug.Log("mouse click started");
        else if (context.performed)
        {
            Debug.Log("mouse click performed");
        }
        else if (context.canceled)
            Debug.Log("mouse click cancelled");
    }

    public void OnPointAction(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 point = context.ReadValue<Vector2>();
            Debug.Log($"Point detected: {point}");

        }
    }
    public void GameOverScene()
    {
        gameOver.Invoke();
    }

    public void OnDie()
    {
        alive = false;
        marioAnimator.Play("mario-die");
        marioDeath.PlayOneShot(marioDeath.clip);
    }

}