using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour {

    public GameObject thisObject;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        thisObject.transform.Rotate(0, 0, Time.deltaTime * 10);
    }
}
