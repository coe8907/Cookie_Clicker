using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cookie_Button : MonoBehaviour {
    private Cookie_Counter cc_script;
    public Button button;

    public int cookiesAwardedOnClick = 1;

    // Use this for initialization
    void Start () {
        cc_script = GetComponent<Cookie_Counter>();
        button.onClick.AddListener(Press);
	}
	void Press()
    {
        cc_script.Add_Cookies(cookiesAwardedOnClick);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
