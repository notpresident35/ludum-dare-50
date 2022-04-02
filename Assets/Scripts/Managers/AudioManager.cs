using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    
    public AudioMixer Mixer;

    float musicIntensity = 0;
    float slowingEffect;
    List<AudioSource> musicSources;

    private void Awake() {
        foreach (Transform child in transform) {
            musicSources.Add (child.GetComponent<AudioSource>());
        }
    }


    public void SetMusicIntensity(float intensity) {
        musicIntensity = intensity;
        // TODO: Implement!!
    }

    public void SlowEffect () {
        // Note: Implement later!
        // Also don't slow down time.timescale directly here - tell gamemanager to do it, so other juice effects don't conflict
    }
}
