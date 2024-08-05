using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ParanormalLight : MonoBehaviour
{
    //[SerializeField] AudioSource cameraSrc;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LightsOut", 100f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LightsOut()
    {
        // cameraSrc.clip = scaryPiano;
        // cameraSrc.Play();
        GetComponent<Light2D>().enabled = false;
    }
}
