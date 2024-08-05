using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMusic : MonoBehaviour
{
    public FinalCutScene music;
    // public Credits credits;
    public AudioSource finalAudio;
    public AudioClip finalAudioClip;

    void Start()
    {

    }

    void Awake()
    {
        // DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (music.triggerFinalMusic == true)
        {
            finalAudio.clip = finalAudioClip;
            finalAudio.Play();
        }
        // if (credits.finalMusicStop == true)
        // {
        //     finalAudio.Stop();
        // }
    }
}
