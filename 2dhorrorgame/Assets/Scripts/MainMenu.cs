using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;

    public GameObject play;
    public GameObject quit;
    public GameObject howToPlay;

    public GameObject back;
    public GameObject howToPlayText;

    public float transitionTime = 1f;

    public void PlayButton()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        play.SetActive(false);
        quit.SetActive(false);
        howToPlay.SetActive(false);

        howToPlayText.SetActive(true);
        back.SetActive(true);
    }

    public void BackButton()
    {
        play.SetActive(true);
        quit.SetActive(true);
        howToPlay.SetActive(true);

        howToPlayText.SetActive(false);
        back.SetActive(false);
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
