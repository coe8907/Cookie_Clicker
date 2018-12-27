using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy_muffin_script : MonoBehaviour {

    // Use this for initialization
    /*Public double cost = ?
    Public int num_muffins = ?
    Public String Pack_name = “”
    Void OnClick(){
	If(player has real world money > cost){
	Muffin-> Muffin_Counter -> add_muffins(num_muffins);
	Take money from players account 
    }
    }
    */
    public int num_muffins = 0;
    public double cost = 0.00;
    public string pack_name = "NOT FOUND";
    private GameObject counter;
    public Text name_text;
    public Text cost_text;

    public void Click()
    {
        counter.GetComponent<Muffin_Counter>().Add_Muffin(num_muffins);
    }
    void Start () {
        counter = GameObject.Find("Muffin_counter");
        name_text.text = string.Format("{0}({1} muffins)",pack_name,num_muffins);
        cost_text.text = string.Format("Cost : £ {0}", cost);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
