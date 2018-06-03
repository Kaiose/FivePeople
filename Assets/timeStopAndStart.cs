using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeStopAndStart : MonoBehaviour {

	public void StopTime()
    {
        Time.timeScale = 0.0f;
    }

    public void StartTime()
    {
        Time.timeScale = 1.0f;
    }
}
