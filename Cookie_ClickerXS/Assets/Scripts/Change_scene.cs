using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Change_scene : MonoBehaviour {
    public string to_scene;
	// Use this for initialization
	void Start () {
       gameObject.GetComponent<Button>().onClick.AddListener(click);
    }
    public void click()
    {
        Application.LoadLevel(to_scene);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
