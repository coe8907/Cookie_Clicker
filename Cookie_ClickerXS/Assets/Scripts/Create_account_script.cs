using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_account_script : MonoBehaviour
{
    public GameObject email;
    public GameObject username;
    public GameObject password;
   
    public GameObject password_con;

    public GameObject button_text;
    public Button button;
    public string to_scene;
    // Use this for initialization
    void Start()
    {
       
        button.onClick.AddListener(create_account);

    }
    void run() { 
}
    void create_account()
    {
       // 
        button_text.GetComponent<Text>().text = "please wait";
         if (password.GetComponent<Text>().text == password_con.GetComponent<Text>().text)
         {
             Debug.Log("Psss word match ??");
             gameObject.GetComponent<Connect_to_SQL>().Add_User(username.GetComponent<Text>().text, password.GetComponent<Text>().text);
             Application.LoadLevel(to_scene);
        }
         else
         {
            button_text.GetComponent<Text>().text = "Passwords dont match";
            Debug.Log(password.GetComponent<Text>().text + "  !=  " + password_con.GetComponent<Text>().text);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
