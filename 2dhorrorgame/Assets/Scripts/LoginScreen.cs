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
    string correctPassword = "26/04/1978";
    string correctPassword1 = "26041978";
    string correctPassword2 = "26-04-1978";

    void Start()
    {
        password = GetComponent<InputField>();
    }

    public void LoginClicked()
    {
        if(password.text == correctPassword || password.text == correctPassword1 || password.text == correctPassword2)
        {
            homeScreen.SetActive(true);
            loginScreen.SetActive(false);   
        }

    }
}
