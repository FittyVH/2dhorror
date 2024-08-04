using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FinalCutScene : MonoBehaviour
{
    public GameObject ghost;
    public GameObject player;
    public GameObject finalText;
    public GameObject paranormalActivity;

    public AudioSource src;
    public AudioClip textSound;

    public GameObject[] text;
    int i = 0;
    int playTrigger = 0;

    bool notMoving = false;
    bool finalTrigger = false;
    bool paranormalActivityDisabled = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (notMoving == true)
        {
            player.GetComponent<Movement>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
        }
        else
        {
            player.GetComponent<Movement>().enabled = true;
            player.GetComponent<Animator>().enabled = true;
        }

        if (paranormalActivityDisabled == true)
        {
            Destroy(GameObject.FindWithTag("Switch"));
            Destroy(paranormalActivity);
            Debug.Log("no paranormal activity");
        }

        if (finalTrigger == true)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && i < text.Length - 1)
            {
                playTrigger = 1;
                if (playTrigger == 1)
                {
                    src.clip = textSound;
                    src.Play();
                }
                text[i].SetActive(false);
                i++;
                text[i].SetActive(true);
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && i == text.Length - 1)
            {
                src.Stop();
                Destroy(GameObject.FindWithTag("FinalCutScene"));
                finalText.SetActive(false);
                notMoving = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FinalCutScene")
        {
            paranormalActivityDisabled = true;
            notMoving = true;
            TriggerCutScene();
        }
    }

    void SpawnGhost()
    {
        ghost.SetActive(true);
    }

    void FinalText()
    {
        finalText.SetActive(true);
        finalTrigger = true;
    }

    void TriggerCutScene()
    {
        Invoke("SpawnGhost", 3f);
        Invoke("FinalText", 6f);
    }
}
