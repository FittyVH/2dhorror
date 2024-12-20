using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Audio;

public class LightManager : MonoBehaviour
{
    [SerializeField] GameObject lights;

    [SerializeField] AudioClip lightSwitch;
    [SerializeField] AudioClip scaryPiano;

    [SerializeField] AudioSource src;
    [SerializeField] AudioSource cameraSrc;

    bool isColliding;
    bool lightOn = false;
    // private bool lightAuto = false;

    void Start()
    {
        InvokeRepeating("LightsOut", 130f, 130f);
        // StartCoroutine(LightsOutCoroutine(100f, 100f));
    }

    void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.E))
        {
            lightOn = !lightOn;
            src.clip = lightSwitch;
            src.Play();
        }
        if (lightOn == true)
        {
            // lightAuto = true;
            lights.GetComponent<Light2D>().enabled = true;
        }
        else if (lightOn == false)
        {
            // lightAuto = false;
            lights.GetComponent<Light2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isColliding = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isColliding = false;
        }   
    }

    void LightsOut()
    {
        src.clip = lightSwitch;
        src.Play();
        cameraSrc.clip = scaryPiano;
        cameraSrc.Play();
        lightOn = !lightOn;
    }

    // IEnumerator LightsOutCoroutine(float initialDelay, float repeatRate)
    // {
    //     yield return new WaitForSeconds(initialDelay);
    //     while (true)
    //     {
    //         LightsOut();
    //         yield return new WaitForSeconds(repeatRate);
    //     }
    // }
}
