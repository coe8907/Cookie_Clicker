using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login_script : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public string to_scene;
    public GameObject button_text;
    public bool offline = false;
    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(click);
        Connect_to_SQL T = gameObject.GetComponent<Connect_to_SQL>();
        if (T.GetConnectionState() != "Open")
        {
            offline = true;
            button_text.GetComponent<Text>().text = "OFFLINE";
        }

    }
    public void click()
    {
        if (!offline)
        {
            button_text.GetComponent<Text>().text = "Please Wait";
            Connect_to_SQL T = gameObject.GetComponent<Connect_to_SQL>();
            string user = username.GetComponent<Text>().text;
            string pass = password.GetComponent<Text>().text;
            if (T.Test_Login(user, pass))
            {
                Application.LoadLevel(to_scene);
            }
            else
            {
                button_text.GetComponent<Text>().text = "Account Not Found";
            }
        }
        else
        {
            Application.LoadLevel(to_scene);
        }
    }
   


    // Update is called once per frame
    void Update()
    {

    }
}
