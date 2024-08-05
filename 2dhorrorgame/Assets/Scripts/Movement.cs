using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2;

    [SerializeField] AudioSource canvasSrc;
    [SerializeField] AudioClip doorOpenAudio;
    [SerializeField] AudioClip doorLockedAudio;
    [SerializeField] AudioClip keySound;
    // [SerializeField] AudioClip basementBg;

    bool stairIsCollidingL = false;
    bool stairIsCollidingDownL = false;
    bool stairIsCollidingR = false;
    bool stairIsCollidingDownR = false;
    bool yourRoomEnterColliding = false;
    bool daughterRoomEnterColliding = false;
    bool yourRoomKeyIsColliding = false;
    bool basementDoorColliding = false;
    bool haveYourRoomKey = false;
    public bool LivingRoomDoorOpen = false;
    bool haveBasementKey = false;///
    bool daughterRoomLockedIsColliding = false;
    public bool daughterRoomUnlocked;
    bool collidingLRDoor = false;

    [SerializeField] GameObject camPosition;
    [SerializeField] GameObject yourRoomKeyColiider;
    [SerializeField] GameObject yourRoomKey;
    [SerializeField] GameObject DRCollider;
    [SerializeField] GameObject basementKeyButton;
    [SerializeField] GameObject daughterRoomLockedCollider;
    [SerializeField] GameObject yourRoomOpenDoor;
    [SerializeField] GameObject daughterRoomOpenDoor;
    [SerializeField] GameObject basementOpenDoor;

    [SerializeField] GameObject blackScreen;
    [SerializeField] GameObject EText;
    [SerializeField] GameObject upStairText;
    [SerializeField] GameObject downStairText;
    [SerializeField] GameObject computerText;
    [SerializeField] GameObject youKeyText;
    [SerializeField] GameObject lockedKeyRequiredText;
    [SerializeField] GameObject openDoorText;
    [SerializeField] GameObject daughterRoomLockedText;
    [SerializeField] GameObject haveBasementKeyText;
    [SerializeField] GameObject pcPromptRoomUnlockedText;
    [SerializeField] GameObject lockedText;
    [SerializeField] GameObject ghostText;

    public bool loadCredits = false;

    SpriteRenderer spriteRenderer;
    AudioSource src;

    public Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        src = GetComponent<AudioSource>();
    }

    void Update()
    {
        MovementSystem();
        StairSystem();
        DoorSystem();
        YourRoomKey();
    }

    void StairSystem()
    {
        if (stairIsCollidingR == true && Input.GetKeyDown(KeyCode.E))
        {
            spriteRenderer.flipX = true;
            camPosition.transform.position = new Vector3(camPosition.transform.position.x, 15f, -10f);
            transform.position = new Vector2(71.72f, 13.23f);
        }
        if (stairIsCollidingDownR == true && Input.GetKeyDown(KeyCode.E))
        {
            spriteRenderer.flipX = true;
            camPosition.transform.position = new Vector3(camPosition.transform.position.x, 0f, -10f);
            transform.position = new Vector2(71.72f, -1.8f);
        }
        if (stairIsCollidingL == true && Input.GetKeyDown(KeyCode.E))
        {
            spriteRenderer.flipX = false;
            camPosition.transform.position = new Vector3(camPosition.transform.position.x, 15f, -10f);
            transform.position = new Vector2(-27f, 13.23f);
        }
        if (stairIsCollidingDownL == true && Input.GetKeyDown(KeyCode.E))
        {
            spriteRenderer.flipX = false;
            camPosition.transform.position = new Vector3(camPosition.transform.position.x, 0f, -10f);
            transform.position = new Vector2(-27f, -1.8f);
        }
    }

    public void DoorSystem()
    {
        if (yourRoomEnterColliding == true && Input.GetKeyDown(KeyCode.E) && haveYourRoomKey == true)
        {
            src.clip = doorOpenAudio;
            src.Play();
            spriteRenderer.flipX = true;
            transform.position = new Vector2(9f, 28.2f);
            camPosition.transform.position = new Vector3(camPosition.transform.position.x, 30f, -10f);
            yourRoomOpenDoor.SetActive(true);
        }
        else if (yourRoomEnterColliding == true && Input.GetKeyDown(KeyCode.E) && haveYourRoomKey == false)
        {
            src.clip = doorLockedAudio;
            src.Play();
        }
        if (daughterRoomEnterColliding == true && Input.GetKeyDown(KeyCode.E))
        {
            src.clip = doorOpenAudio;
            src.Play();
            transform.position = new Vector2(14.1f, 28.2f);
            camPosition.transform.position = new Vector3(camPosition.transform.position.x + 20.9f, 30f, -10f);
            daughterRoomOpenDoor.SetActive(true);
        }
        if (basementDoorColliding == true && Input.GetKeyDown(KeyCode.E) && haveBasementKey == true)
        {
            src.clip = doorOpenAudio;
            src.Play();
            // canvasSrc.clip = basementBg;
            // canvasSrc.Play();
            camPosition.transform.position = new Vector3(camPosition.transform.position.x, -15f, -10f);
            transform.position = new Vector2(71.5f, -16.75f);
            basementOpenDoor.SetActive(true);
        }
        else if (basementDoorColliding == true && Input.GetKeyDown(KeyCode.E) && haveBasementKey == false)
        {
            src.clip = doorLockedAudio;
            src.Play();
        }
        if (daughterRoomLockedIsColliding == true && Input.GetKeyDown(KeyCode.E))
        {
            src.clip = doorLockedAudio;
            src.Play();
        }
        if (collidingLRDoor == true && Input.GetKeyDown(KeyCode.E) && LivingRoomDoorOpen == false)
        {
            src.clip = doorLockedAudio;
            src.Play();
        }
        if (collidingLRDoor == true && Input.GetKeyDown(KeyCode.E) && LivingRoomDoorOpen == true)
        {
            GetComponent<Movement>().enabled = false;
            blackScreen.SetActive(true);
            loadCredits = true;
        }
    }

    void YourRoomKey()
    {
        if (yourRoomKeyIsColliding == true && Input.GetKeyDown(KeyCode.E))
        {
            src.clip = keySound;
            src.Play();
            haveYourRoomKey = true;
            Destroy(yourRoomKeyColiider);
            Destroy(yourRoomKey);
        }
    }

    public void DaughterRoomUnlocked()
    {
        pcPromptRoomUnlockedText.SetActive(true);
        daughterRoomUnlocked = true;
        DRCollider.transform.position = new Vector2(7.447f, 13.51f);
        Destroy(daughterRoomLockedCollider);
    }

    public void BasementUnlocked()
    {
        haveBasementKeyText.SetActive(true);
        Invoke("DisableBasementKeyText", 3f);
        src.clip = keySound;
        src.Play();
        haveBasementKey = true;
        Destroy(basementKeyButton);
    }

    void MovementSystem()
    {
        if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            animator.SetFloat("Speed", 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("Speed", 1);
            spriteRenderer.flipX = true;
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Wall_R")
        {
            transform.position = new Vector2(transform.position.x + 2.5f , transform.position.y);
            camPosition.transform.position = new Vector3(camPosition.transform.position.x + 20.9f, camPosition.transform.position.y, -10);
        }
        if (other.gameObject.tag == "Wall_L")
        {
            transform.position = new Vector2(transform.position.x - 2.5f , transform.position.y);
            camPosition.transform.position = new Vector3(camPosition.transform.position.x - 20.9f, camPosition.transform.position.y, -10);
        }
        if (other.gameObject.tag == "Wall_DR")
        {
            transform.position = new Vector2(7.44f , 13.23f);
            camPosition.transform.position = new Vector3(1.1f, 15f, -10);
        }
        if (other.gameObject.tag == "Wall_YR")
        {
            transform.position = new Vector2(-5.26f , 13.23f);
            camPosition.transform.position = new Vector3(1.1f, 15f, -10);
        }
        if (other.gameObject.tag == "Wall_DS_L")
        {
            transform.position = new Vector2(54.82f , 13.23f);
            camPosition.transform.position = new Vector3(63.86f, 15f, -10);
        }
        if (other.gameObject.tag == "Wall_DS_R")
        {
            transform.position = new Vector2(10.12f , 13.23f);
            camPosition.transform.position = new Vector3(1.1f, 15f, -10);
        }
        if (other.gameObject.tag == "Stair_U")
        {
            stairIsCollidingL = true;
            upStairText.SetActive(true);
        }
        if (other.gameObject.tag == "Stair_D")
        {
            stairIsCollidingDownL = true;
            downStairText.SetActive(true);
        } 
        if (other.gameObject.tag == "Stair_U_R")
        {
            stairIsCollidingR = true;
            upStairText.SetActive(true);
        }
        if (other.gameObject.tag == "Stair_D_R")
        {
            stairIsCollidingDownR = true;
            downStairText.SetActive(true);
        }
        if (other.gameObject.tag == "YourRoomEnter")
        {
            yourRoomEnterColliding = true;
            if (haveYourRoomKey == true)
            {
                openDoorText.SetActive(true);
            }
            else if (haveYourRoomKey == false)
            {
                lockedKeyRequiredText.SetActive(true);
            }
        }
        if (other.gameObject.tag == "DaughterRoomEnter")
        {
            daughterRoomEnterColliding = true;
            openDoorText.SetActive(true);
        }
        if (other.gameObject.tag == "YourRoomKey")
        {
            yourRoomKeyIsColliding = true;
            youKeyText.SetActive(true);
        }
        if (other.gameObject.tag == "Switch")
        {
            EText.SetActive(true);
        }
        if (other.gameObject.tag == "Computer")
        {
            computerText.SetActive(true);
        }
        if (other.gameObject.tag == "BasementDoor")
        {
            basementDoorColliding = true;
            if (haveBasementKey == true)
            {
                openDoorText.SetActive(true);
            }
            else if (haveBasementKey == false)
            {
                lockedKeyRequiredText.SetActive(true);
            }
        }
        if (other.gameObject.tag == "DaughterRoomLocked")
        {
            daughterRoomLockedText.SetActive(true);
            daughterRoomLockedIsColliding = true;
        }
        if (other.gameObject.tag == "LivingRoomDoor")
        {
            collidingLRDoor = true;
            if (LivingRoomDoorOpen == false)
            {
                lockedText.SetActive(true);
            }
            else if (LivingRoomDoorOpen == true)
            {
                openDoorText.SetActive(true);
            }
        }
        if (other.gameObject.tag == "Ghost")
        {
            ghostText.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Stair_U")
        {
            stairIsCollidingL = false;
            upStairText.SetActive(false);
        }
        if (other.gameObject.tag == "Stair_D")
        {
            stairIsCollidingDownL = false;
            downStairText.SetActive(false);
        }
        if (other.gameObject.tag == "Stair_U_R")
        {
            stairIsCollidingR = false;
            upStairText.SetActive(false);
        }
        if (other.gameObject.tag == "Stair_D_R")
        {
            stairIsCollidingDownR = false;
            downStairText.SetActive(false);
        }
        if (other.gameObject.tag == "YourRoomEnter")
        {
            yourRoomEnterColliding = false;
            openDoorText.SetActive(false);
            lockedKeyRequiredText.SetActive(false);
        }  
        if (other.gameObject.tag == "DaughterRoomEnter")
        {
            daughterRoomEnterColliding = false;
            openDoorText.SetActive(false);
        }
        if (other.gameObject.tag == "YourRoomKey")
        {
            yourRoomKeyIsColliding = false;
            youKeyText.SetActive(false);
        }
        if (other.gameObject.tag == "Switch")
        {
            EText.SetActive(false);
        }
        if (other.gameObject.tag == "Computer")
        {
            computerText.SetActive(false);
        }
        if (other.gameObject.tag == "BasementDoor")
        {
            basementDoorColliding = false;
            openDoorText.SetActive(false);
            lockedKeyRequiredText.SetActive(false);
        }
        if (other.gameObject.tag == "DaughterRoomLocked")
        {
            daughterRoomLockedText.SetActive(false);
            daughterRoomLockedIsColliding = false;
        }
        if (other.gameObject.tag == "LivingRoomDoor")
        {
            lockedText.SetActive(false);
            collidingLRDoor = false;
        }
        if (other.gameObject.tag == "Ghost")
        {
            ghostText.SetActive(false);
        }
    }

    void DisableBasementKeyText()
    {
        haveBasementKeyText.SetActive(false);
    }
}
