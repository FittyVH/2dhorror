using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public Movement movement;

    // public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        if (movement.loadCredits == true)
        {
            Invoke("LoadNextScene", 4f);
            // Invoke("DestroyThis", 29f);
        }
    }

    void LoadNextScene()
    {
        StartCoroutine(LoadLevel(4));
    }

    // void DestroyThis()
    // {
    //     Destroy(player);
    // }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
