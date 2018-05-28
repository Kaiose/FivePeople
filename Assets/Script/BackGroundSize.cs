using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSize : MonoBehaviour {

	// Use this for initialization

    void Awake()
    {


        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(545, 969, false);
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
