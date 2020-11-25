using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource soundEffect1;
    public AudioSource soundEffect2;

    private bool isMuted = false;

    void Start()
    {
        InvokeRepeating("PlayAudioClip", 0.1f, 30.0f);
    }

    void PlayAudioClip() {
        soundEffect1.Play();
    }

    public void MuteUnmuteEffectImmediately()
    {
        isMuted = !isMuted;

        if (isMuted) {
            soundEffect1.volume = 0.0f;
        } else {
            soundEffect1.volume = 1.0f;
        }
    }

    /*
    public void PlaySoundEffect1()
    {
        soundEffect1.Play();
    }

    public void PlaySoundEffect2()
    {
        soundEffect2.Play();
    }
    */
}
