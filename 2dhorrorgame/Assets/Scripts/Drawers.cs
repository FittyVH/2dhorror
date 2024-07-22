using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawers : MonoBehaviour
{
    [SerializeField] GameObject drawer;
    [SerializeField] GameObject player;

    [SerializeField] AudioSource src;
    [SerializeField] AudioClip drawerOpenAudio;

    [SerializeField] GameObject idCardDrawer;
    [SerializeField] GameObject idCardButton;

    [SerializeField] GameObject UIText;

    [SerializeField] GameObject UIElements;

    bool isColliding = false;
    bool drawerOpen = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.E))
        {
            drawerOpen = !drawerOpen;
            src.clip = drawerOpenAudio;
            src.Play();
        }
        if (drawerOpen == true)
        {
            drawer.GetComponent<SpriteRenderer>().sortingLayerName = "drawers";
            player.GetComponent<Movement>().enabled = false;
            UIText.SetActive(false);
            UIElements.SetActive(true);

        }
        else if (drawerOpen == false)
        {
            drawer.GetComponent<SpriteRenderer>().sortingLayerName = "default";
            player.GetComponent<Movement>().enabled = true;
            UIElements.SetActive(false);
            idCardDrawer.GetComponent<SpriteRenderer>().sortingLayerName = "default";
            idCardButton.SetActive(false);
            UIElements.GetComponent<Button>().enabled = true;
            UIElements.GetComponent<Image>().enabled = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isColliding = true;
            UIText.SetActive(true);
        }    
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isColliding = false;
            UIText.SetActive(false);
        }    
    }

    public void DrawerClicked()
    {
        UIElements.GetComponent<Button>().enabled = false;
        UIElements.GetComponent<Image>().enabled = false;
        idCardDrawer.GetComponent<SpriteRenderer>().sortingLayerName = "drawers";
        idCardButton.SetActive(true);
    }
}
