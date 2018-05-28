using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
public class SettingButtonClick : MonoBehaviour {

   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
        print("SettingButtonClick");
        EventManager.EventInstance.CallFadeOut();
    }
}
