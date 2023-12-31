using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public bool isFadingIn = false;
    public bool isFadingOut = false;

    public float timeToFade;

    // Update is called once per frame
    void Update()
    {
        if (isFadingIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += timeToFade * Time.deltaTime;
                if (canvasGroup.alpha >= 1)
                {
                    canvasGroup.alpha = 1; // Ensure the alpha is set to exactly 1
                    isFadingIn = false;
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
                }
            }
        }
    }

    // Renamed method to avoid naming conflict with class name
    public void StartFadeIn()
    {
        isFadingIn = true;
        isFadingOut = false; // Stop fading out if it is in progress
    }

    public void StartFadeOut()
    {
        isFadingOut = true;
        isFadingIn = false; // Stop fading in if it is in progress
    }
}
