using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Muffin_Counter : MonoBehaviour {
    private int muffin_count = 0;
    public Text text_box;
    // Use this for initialization
    public void Add_Muffin(int num)
    {
        muffin_count += num;
        text_box.text = string.Format("Muffins : {0}", muffin_count);
    }
    public bool Can_buy(int cost)
    {
        if (muffin_count >= cost)
        {
            muffin_count -= cost;
            text_box.text = string.Format("Muffins : {0}", muffin_count); 
            return true;
        }
        return false;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
