using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuffinButton : MonoBehaviour {

    public GameObject premiumPanel;
    public GameObject scrollPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void TogglePremiumPanel()
    {
        scrollPanel.SetActive(false);
        premiumPanel.SetActive(!premiumPanel.activeSelf);
    }

}
