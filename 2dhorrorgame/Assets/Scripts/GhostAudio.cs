using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GhostAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().spatialBlend = 0.5f;
        }    
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Pause();
            GetComponent<AudioSource>().spatialBlend = 1f;
        }  
    }
}
