using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGUI : MonoBehaviour {

    public GameObject MainMenuUI;
    public GameObject settingUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onCallSettingUI()
    {
        MainMenuUI.SetActive(settingUI.activeSelf);
        settingUI.SetActive(!settingUI.activeSelf);
    }

    public void onQuitButton()
    {
        Application.Quit();
    }
}
