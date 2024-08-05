using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LivingRoomTubeLight : MonoBehaviour
{
    [SerializeField] GameObject lights;
    [SerializeField] GameObject player;
    [SerializeField] GameObject ghost;
    public GameObject blackScreen;

    [SerializeField] AudioSource src;
    [SerializeField] AudioSource cmSrc;
    [SerializeField] AudioClip lightSwitch;
    [SerializeField] AudioClip scaryPiano;

    public Animator transition;

    private bool isColliding;
    private bool lightOn = false;

    public float transitionTime = 1f;
    int i = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.E))
        {
            i++;
            lightOn = !lightOn;
            src.clip = lightSwitch;
            src.Play();
        }
        if (lightOn == true)
        {
            lights.GetComponent<Light2D>().enabled = true;
            Invoke("AutoOff", 1);
        }
        else if (lightOn == false)
        {
            lights.GetComponent<Light2D>().enabled = false;
        }

        if (i >= 5)
        {
            lights.GetComponent<Light2D>().enabled = true;
            Death();
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isColliding = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            isColliding = false;
        }   
    }
    void AutoOff()
    {
        lightOn = false;
    }
    void Death()
    {
        player.GetComponent<Movement>().enabled = false;
        Invoke("SpawnGhost", 2f);
        Invoke("SceneTransition", 4f);
    }
    void SpawnGhost()
    {
        ghost.GetComponent<SpriteRenderer>().flipX = true;
        ghost.transform.position = new Vector2(player.transform.position.x - 1.4f, ghost.transform.position.y);
    }
    public void SceneTransition()
    {
        blackScreen.SetActive(true);
        Destroy(GameObject.FindWithTag("Player"));
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
