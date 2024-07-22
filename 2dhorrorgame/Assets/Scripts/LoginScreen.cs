using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.ComponentModel;

public class LoginScreen : MonoBehaviour
{
    [SerializeField] GameObject loginScreen;
    [SerializeField] GameObject homeScreen;

    private InputField password;
    string correctPassword = "26-04-1978";

    void Start()
    {
        password = GetComponent<InputField>();
    }

    public void LoginClicked()
    {
        if(password.text == correctPassword)
        {
            homeScreen.SetActive(true);
            loginScreen.SetActive(false);   
        }

    }
}
