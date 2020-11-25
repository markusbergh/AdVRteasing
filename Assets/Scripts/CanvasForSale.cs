using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasForSale : MonoBehaviour
{
    public CanvasGroup primary;
    public CanvasGroup secondary;

    public void OnEnter()
    {
        StartCoroutine(CanvasUtility.FadeCanvas(primary, 1f, 0f, 0.05f));
        StartCoroutine(CanvasUtility.FadeCanvas(secondary, 0f, 1f, 0.5f));
    }

    public void OnExit()
    {
        StartCoroutine(CanvasUtility.FadeCanvas(secondary, 1f, 0f, 0.05f));
        StartCoroutine(CanvasUtility.FadeCanvas(primary, 0f, 1f, 0.5f));
    }
}
