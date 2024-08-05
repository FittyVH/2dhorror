using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public float creditSpeed = 2f;

    public Animator transition;
    public float transitionTime = 1f;

    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y < 5140f)
        {
            Invoke("MoveText", 3f);
        }
        else
        {
            StartCoroutine(LoadLevel(0));
        }
    }

    void MoveText()
    {
        transform.Translate(0, creditSpeed * Time.deltaTime, 0);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
