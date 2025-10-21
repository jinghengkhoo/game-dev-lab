using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioStateController : StateController
{
    public PowerupType currentPowerupType = PowerupType.Default;
    public MarioState shouldBeNextState = MarioState.Default;
    private SpriteRenderer spriteRenderer;
    public GameConstants gameConstants;
    public MarioActions marioActions;

    public MarioFeet feet;
    public MarioBody body;

    public void Awake()
    {
        if (marioActions == null)
            marioActions = new MarioActions();
    }

    public override void Start()
    {
        base.Start();
        GameRestart(); // clear powerup in the beginning, go to start state
        marioActions.gameplay.Enable();
        marioActions.gameplay.attack.performed += ctx => Fire();
    }

    // this should be added to the GameRestart EventListener as callback
    public void GameRestart()
    {
        // clear powerup
        currentPowerupType = PowerupType.Default;
        // set the start state
        TransitionToState(startState);
    }

    public void SetPowerup(PowerupType i)
    {
        currentPowerupType = i;
        if (i == PowerupType.MagicMushroom || i == PowerupType.FireFlower)
        {
            feet.BigMario();
            body.BigMario();
        }
        else
        {
            feet.SmallMario();
            body.SmallMario();
        }
    }

    public void SetRendererToFlicker()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(BlinkSpriteRenderer());
    }
    private IEnumerator BlinkSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        while (string.Equals(currentState.name, "InvincibleSmallMario", StringComparison.OrdinalIgnoreCase))
        {
            // Toggle the visibility of the sprite renderer
            spriteRenderer.enabled = !spriteRenderer.enabled;

            // Wait for the specified blink interval
            yield return new WaitForSeconds(gameConstants.flickerInterval);
        }

        spriteRenderer.enabled = true;
    }
    public void Fire()
    {
        this.currentState.DoEventTriggeredActions(this, ActionType.Attack);
    }
}