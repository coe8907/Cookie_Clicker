using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaders_script : MonoBehaviour {
    public GameObject o_name;
    public GameObject o_score;

	// Use this for initialization
    public void set_up(string name, int score)
    {
        o_name.GetComponent<Text>().text = name;
        o_score.GetComponent<Text>().text = score.ToString();

    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
