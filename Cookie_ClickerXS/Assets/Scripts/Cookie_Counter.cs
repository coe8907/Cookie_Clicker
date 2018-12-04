using System.Collections;
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
        num_cookies += num;
        text_box.text = string.Format("Cookies: {0}",num_cookies);
    }
    public bool Can_buy(int cost)
    {
        if(num_cookies >= cost)
        {
            num_cookies -= cost;
            return true;
        }
        return false;
    }

}
