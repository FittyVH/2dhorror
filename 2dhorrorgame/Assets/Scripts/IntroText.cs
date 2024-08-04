using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroText : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public AudioSource src;
    public AudioClip textSound;

    public GameObject[] text;
    int i = 0;
    int playTrigger = 0;

    void Start()
    {
        for (int j = 1; j < text.Length; j++)
        {
            text[j].SetActive(false);
        }
        if (text.Length > 0)
        {
            text[0].SetActive(true);
        }
    }

    void Update()
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
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}