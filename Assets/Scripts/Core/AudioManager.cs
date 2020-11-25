using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public bool playOnStart = false;

    void Awake()
    {
        if (playOnStart)
        {
            backgroundMusic.Play();
        }
    }

    public void FadeInMusic(float Volume) {
        IEnumerator fadeSound = AudioFadeOut.FadeIn(backgroundMusic, 0.5f, Volume);
        StartCoroutine(fadeSound);
    }

    public void FadeOutMusic()
    {
        IEnumerator fadeSound = AudioFadeOut.FadeOut(backgroundMusic, 0.5f);
        StartCoroutine(fadeSound);
    }
}

public static class AudioFadeOut
{
    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime, float Volume)
    {
        audioSource.volume = 0.0f;
        audioSource.Play();

        float endVolume = 1.0f;

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += endVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = endVolume;
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Pause();
        audioSource.volume = startVolume;
    }
}