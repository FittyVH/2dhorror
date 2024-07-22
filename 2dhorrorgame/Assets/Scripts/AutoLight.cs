using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AutoLight : MonoBehaviour
{
    [SerializeField] GameObject lightObject;

    void Start()
    {
        lightObject.GetComponent<Light2D>().enabled = false;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            lightObject.GetComponent<Light2D>().enabled = true;
        }
    }
}
