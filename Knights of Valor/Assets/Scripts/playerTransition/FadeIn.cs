using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool isFadingIn = false;
    public bool isFadingOut = false;
    public PlayerMovement playerobj; // Set this reference in the Unity Editor
    public float timeToFade;

    private bool isDelayingMovement = false;
    public float delayTime = 3.0f; // Adjust this value to set the delay time before allowing movement again
    private float delayTimer = 0f;

    void Update()
    {
        if (isDelayingMovement)
        {
            delayTimer += Time.deltaTime;
            if (delayTimer >= delayTime)
            {
                SetPlayerMovement(true); // Enable player movement after delay
                isDelayingMovement = false;
                delayTimer = 0f; // Reset the timer for the next use
            }
        }

        if (isFadingIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += timeToFade * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    canvasGroup.alpha = 1; // Ensure the alpha is set to exactly 1
                    isFadingIn = false;
                    StartDelay(); // Start the delay before allowing movement
                }
            }
        }

        if (isFadingOut)
        {
            if (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= timeToFade * Time.deltaTime;
                if (canvasGroup.alpha <= 0)
                {
                    canvasGroup.alpha = 0; // Ensure the alpha is set to exactly 0
                    isFadingOut = false;
                    StartDelay(); // Start the delay before allowing movement
                }
            }
        }
    }

    void StartDelay()
    {
        isDelayingMovement = true;
    }

    public void StartFadeIn()
    {
        isFadingIn = true;
        isFadingOut = false; // Stop fading out if it is in progress
        SetPlayerMovement(false); // Disable movement when fading in starts
    }

    public void StartFadeOut()
    {
        isFadingOut = true;
        isFadingIn = false; // Stop fading in if it is in progress
        SetPlayerMovement(false); // Disable movement when fading out starts
    }

    private void SetPlayerMovement(bool canMove)
    {
        if (playerobj != null)
        {
            playerobj.canMove = canMove;
        }
    }
}