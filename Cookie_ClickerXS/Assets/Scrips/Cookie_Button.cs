using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cookie_Button : MonoBehaviour {
    private Cookie_Counter cc_script;
    public Button button;
    // Use this for initialization
    void Start () {
        cc_script = GetComponent<Cookie_Counter>();
        button.onClick.AddListener(Press);
	}
	void Press()
    {
        cc_script.Add_Cookies(1);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
