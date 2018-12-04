using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour {
    public GameObject ScrollPanel;
    public GameObject muffin_Panel;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ToggleUpgradePanel()
    {
        muffin_Panel.SetActive(false);
        ScrollPanel.SetActive(!ScrollPanel.activeSelf);
    }
}
