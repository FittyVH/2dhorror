using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{   
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject player;

    bool pauseMenuOn = false;

    void Start()
    {

    }

    void Update()
    {
        if (pauseMenuOn == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            player.GetComponent<Animator>().enabled = false;
            pauseMenu.SetActive(true);
            pauseMenuOn = true;
        }
        else if (pauseMenuOn == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
            pauseMenuOn = false;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        player.GetComponent<Animator>().enabled = true;
        pauseMenu.SetActive(false);
        pauseMenuOn = false;
    }

    public void QuitClicked()
    {
        Application.Quit();
    }
}
