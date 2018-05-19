using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSize : MonoBehaviour {

	void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1089, 1939, false);
    }
}
