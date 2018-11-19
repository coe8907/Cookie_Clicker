using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuffinButton : MonoBehaviour {

    public GameObject premiumPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void TogglePremiumPanel()
    {
        premiumPanel.SetActive(!premiumPanel.activeSelf);
    }

}
