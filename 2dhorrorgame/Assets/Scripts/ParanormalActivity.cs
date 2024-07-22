using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ParanormalActivity : MonoBehaviour
{
    [SerializeField] AudioSource src;
    [SerializeField] AudioClip ghostGroanLeft;
    [SerializeField] AudioClip ghostGroanRight;
    [SerializeField] AudioClip ghostRunLeft;
    [SerializeField] AudioClip ghostRunRight;

    private List<Action> functions = new List<Action>();

    void Start()
    {
        functions.Add(GhostGroanLeft);
        functions.Add(GhostGroanRight);
        functions.Add(GhostRunLeft);
        functions.Add(GhostRunRight);

        InvokeRepeating("InvokeRandomEvent", 50f, 50f);
    }

    void InvokeRandomEvent()
    {
        functions[UnityEngine.Random.Range(0, functions.Count)].Invoke();
    }

    void Update() 
    {

    }

    private void GhostGroanLeft()
    {
        src.clip = ghostGroanLeft;
        src.Play();
        Invoke("StopSound", 6f);
    }

    private void GhostGroanRight()
    {
        src.clip = ghostGroanRight;
        src.Play();
        Invoke("StopSound", 6f);
    }

    private void GhostRunLeft()
    {
        src.clip = ghostRunLeft;
        src.Play();
    }

    private void GhostRunRight()
    {
        src.clip = ghostRunRight;
        src.Play();
    }

    void StopSound()
    {
        src.Stop();
    }
}

