using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BasementToStairs : MonoBehaviour
{
    public GameObject player;
    public GameObject cmr;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            player.transform.position = new Vector2(62.87f, -1.8f);
            cmr.transform.position = new Vector3(63.8f, 0f, -10f);
        }
    }
}
