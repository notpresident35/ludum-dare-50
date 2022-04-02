using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AnimationCurve IntensityCurve;
    
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Awake() {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    
    void Update() {
        audioManager.SetMusicIntensity(IntensityCurve.Evaluate(Time.time));
    }
}
