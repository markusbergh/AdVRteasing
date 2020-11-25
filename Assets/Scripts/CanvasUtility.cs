using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUtility : MonoBehaviour
{
    public static IEnumerator FadeCanvas(CanvasGroup canvas, float startAlpha, float endAlpha, float duration)
    {
        // Keep track of when the fading started, when it should finish, and how long it has been running
        var startTime = Time.time;
        var endTime = Time.time + duration;
        var elapsedTime = 0f;

        // Set the canvas to the start alpha – this ensures that the canvas is ‘reset’ if you fade it multiple times
        canvas.alpha = startAlpha;

        // Loop repeatedly until the previously calculated end time
        while (Time.time <= endTime)
        {
            // Update the elapsed time
            elapsedTime = Time.time - startTime;

            // Calculate how far along the timeline we are
            var percentage = 1 / (duration / elapsedTime);
            if (startAlpha > endAlpha) // if we are fading out/down
            {
                // Calculate the new alpha
                canvas.alpha = startAlpha - percentage;
            }
            else // if we are fading in/up
            {
                // Calculate the new alpha
                canvas.alpha = startAlpha + percentage;
            }

            // Wait for the next frame before continuing the loop
            yield return new WaitForEndOfFrame();
        }
        // Force the alpha to the end alpha before finishing – this is here to mitigate any rounding errors, e.g. leaving the alpha at 0.01 instead of 0
        canvas.alpha = endAlpha;
    }
}
