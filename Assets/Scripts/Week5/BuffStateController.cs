using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffStateController : StateController
{
    public BuffType currentBuffType = BuffType.Default;
    public MarioBuffState shouldBeNextState = MarioBuffState.Default;
    private SpriteRenderer spriteRenderer;

    public float fadeDuration = 0.6f;

    public void Awake()
    {
    }

    public override void Start()
    {
        base.Start();
        GameRestart();
    }

    // this should be added to the GameRestart EventListener as callback
    public void GameRestart()
    {
        currentBuffType = BuffType.Default;
        // set the start state
        TransitionToState(startState);
    }

    public void SetPowerup(BuffType i)
    {
        currentBuffType = i;
    }

    public void SetRendererToFadeBlack()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeBlackCycle());
    }
    private IEnumerator FadeBlackCycle()
    {
        Color normalColor = Color.white;
        Color blackColor = Color.black;

        while (string.Equals(currentState.name, "Starman", StringComparison.OrdinalIgnoreCase))
        {
            // fade to black
            float t = 0f;
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                float lerpVal = t / fadeDuration;
                spriteRenderer.color = Color.Lerp(normalColor, blackColor, lerpVal);
                yield return null;
            }

            // fade back to normal
            t = 0f;
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                float lerpVal = t / fadeDuration;
                spriteRenderer.color = Color.Lerp(blackColor, normalColor, lerpVal);
                yield return null;
            }
        }

        spriteRenderer.color = Color.white;
    }
}