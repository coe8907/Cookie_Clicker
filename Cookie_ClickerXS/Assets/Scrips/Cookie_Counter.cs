﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cookie_Counter : MonoBehaviour {
    public int num_cookies = 0;
    public Text text_box;
	// Use this for initialization
	void Start () {
		
	}
	public void Add_Cookies(int num)
    {
        text_box.text = "this has been changed";
        num_cookies += num;
    }

}
