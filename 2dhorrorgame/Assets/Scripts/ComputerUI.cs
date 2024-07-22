using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerUI : MonoBehaviour
{
    private bool playerIsColliding = false;
    private bool uiOnScreen = false;

    [SerializeField] GameObject yourPlayer;
    [SerializeField] GameObject computerUI;

    void Start()
    {
        
    }

    void Update()
    {
        UiPopUpSystem();
    }

    void UiPopUpSystem()
    {
        if(playerIsColliding == true && Input.GetKeyDown(KeyCode.E))
        {
            uiOnScreen = true;
        }
        if(playerIsColliding == true && Input.GetKeyDown(KeyCode.Q))
        {
            uiOnScreen = false;
        }
        if(uiOnScreen == true)
        {
            yourPlayer.GetComponent<Movement>().enabled = false;
            computerUI.SetActive(true);
        }
        else if(uiOnScreen == false)
        {
            yourPlayer.GetComponent<Movement>().enabled = true;
            computerUI.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsColliding = false;
        }
    }
}
