using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdFreeZone : MonoBehaviour
{
    private GameObject[] gameObjects;
    private GameObject worldLight;

    void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("AdvertisingSpace");
        worldLight = GameObject.FindGameObjectWithTag("Light");
    }

    void FadeOutAndHideGameObjects()
    {
        foreach (GameObject advertisingGameObject in gameObjects)
        {
            MeshRenderer[] meshRenderers = advertisingGameObject.GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                Material material = meshRenderer.material;
                StartCoroutine(FadeTo(material, 0.0f, 1.0f));
            }
        }
    }

    void FadeInAndShowGameObjects()
    {
        foreach (GameObject advertisingGameObject in gameObjects)
        {
            MeshRenderer[] meshRenderers = advertisingGameObject.GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                Material material = meshRenderer.material;
                StartCoroutine(FadeTo(material, 1.0f, 1.0f));
            }
        }
    }

    void FadeOutAndHideCanvasGroups()
    {
        GameObject[] canvasGroups = GameObject.FindGameObjectsWithTag("AdvertisingSpaceCanvas");

        foreach (GameObject canvasGroup in canvasGroups)
        {
            StartCoroutine(CanvasUtility.FadeCanvas(canvasGroup.GetComponent<CanvasGroup>(), 1.0f, 0.0f, 0.5f));
        }
    }

    void FadeInAndShowCanvasGroups()
    {
        GameObject[] canvasGroups = GameObject.FindGameObjectsWithTag("AdvertisingSpaceCanvas");

        foreach (GameObject canvasGroup in canvasGroups)
        {
            StartCoroutine(CanvasUtility.FadeCanvas(canvasGroup.GetComponent<CanvasGroup>(), 0.0f, 1.0f, 0.5f));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("GameMusic").GetComponent<AudioManager>().FadeOutMusic();
        GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<SoundEffects>().MuteUnmuteEffectImmediately();

        FadeOutAndHideGameObjects();
        FadeOutAndHideCanvasGroups();

        StartCoroutine(Sunset(worldLight.GetComponent<Light>(), 0.5f));
    }

    void OnTriggerExit(Collider other)
    {
        GameObject.FindGameObjectWithTag("GameMusic").GetComponent<AudioManager>().FadeInMusic(1.0f);
        GameObject.FindGameObjectWithTag("SoundEffects").GetComponent<SoundEffects>().MuteUnmuteEffectImmediately();

        FadeInAndShowGameObjects();
        FadeInAndShowCanvasGroups();

        StartCoroutine(Sunrise(worldLight.GetComponent<Light>(), 0.5f));
    }

    // Define an enumerator to perform our sunset and sunrise.
    IEnumerator Sunset(Light light, float duration)
    {
        float t = 0;

        while (t < duration)
        {
            // Step the fade forward one frame.
            t += Time.deltaTime;

            float blend = Mathf.Clamp01(t / duration);

            light.intensity = Mathf.Lerp(1.0f, 0.0f, blend);

            yield return null;
        }
    }

    IEnumerator Sunrise(Light light, float duration)
    {
        float t = 0;

        while (t < duration)
        {
            // Step the fade forward one frame.
            t += Time.deltaTime;

            float blend = Mathf.Clamp01(t / duration);

            light.intensity = Mathf.Lerp(0.0f, 1.0f, blend);

            yield return null;
        }
    }

    // Define an enumerator to perform our fading.
    // Pass it the material to fade, the opacity to fade to (0 = transparent, 1 = opaque),
    // and the number of seconds to fade over.
    IEnumerator FadeTo(Material material, float targetOpacity, float duration)
    {

        // Cache the current color of the material, and its initiql opacity.
        Color color = material.color;
        float startOpacity = color.a;

        // Track how many seconds we've been fading.
        float t = 0;

        while (t < duration)
        {
            // Step the fade forward one frame.
            t += Time.deltaTime;

            // Turn the time into an interpolation factor between 0 and 1.
            float blend = Mathf.Clamp01(t / duration);

            // Blend to the corresponding opacity between start & target.
            color.a = Mathf.Lerp(startOpacity, targetOpacity, blend);

            // Apply the resulting color to the material.
            material.color = color;

            // Wait one frame, and repeat.
            yield return null;
        }
    }
}
