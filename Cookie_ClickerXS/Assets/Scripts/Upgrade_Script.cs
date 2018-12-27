using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_Script : MonoBehaviour {

    // Use this for initialization
    public int cost_c;
    public int cost_m;
    public int Cookies_perLevel_sec = 0;
    public int level = 0;
    public GameObject M_cost;
    private GameObject Cookie;
    private GameObject muffin;
    public GameObject Level_text;
    
   

	void Start () {
        //load from save file
        Cookie = GameObject.Find("Cookie");
        muffin = GameObject.Find("Muffin_counter");
        this.GetComponent<Text>().text = string.Format("Cost: {0}", cost_c);
        M_cost.GetComponent<Text>().text = string.Format("Cost: {0}", cost_m);
        Level_text.GetComponent<Text>().text = string.Format("Level: {0}", level);
    }
    //when app closes
    // save game state



    // Update is called once per frame
    float oldtime = 0;
    void Update () {
        if (oldtime < Time.realtimeSinceStartup)
        {
            Cookie.GetComponent<Cookie_Counter>().Add_Cookies(Cookies_perLevel_sec * level);
            oldtime = Time.realtimeSinceStartup + 1;
        }

	}
    public void Buy_upgrade_c()
    {
        if (Cookie.GetComponent<Cookie_Counter>().Can_buy(cost_c) == true)
        {
            level++;
            cost_c = cost_c * 2;
            this.GetComponent<Text>().text = string.Format("Cost: {0}", cost_c);
            Level_text.GetComponent<Text>().text = string.Format("Level: {0}", level);
        }

    }
    public void Buy_upgrade_m()
    {
        if (muffin.GetComponent<Muffin_Counter>().Can_buy(cost_m) == true)
        {
            level++;
            M_cost.GetComponent<Text>().text = string.Format("Cost: {0}", cost_m);
            Level_text.GetComponent<Text>().text = string.Format("Level: {0}", level);
        }

    }

}
