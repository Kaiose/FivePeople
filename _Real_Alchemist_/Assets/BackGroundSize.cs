using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 *  화면의 사이즈를 고정시키려고 넣은 코드지만, 작동을 하긴 하는데 build를 하면, UI가 맞지 않는다.
 *  Canvas Scaler를 조정했음에도 불구하고 맞지 않는다. 
 *  ㅅㅂ 
*/


public class BackGroundSize : MonoBehaviour {

	void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(545, 969, false);
    }
}
