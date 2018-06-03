using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour {

    public GameObject _Destroy;

    [SerializeField]
    private float time_ = 500.0f;


    private bool off;
	// Use this for initialization
	void Start () {
        off = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (off == true)
        {
            time_ -= 1.0f;
            if (time_ <= 0.0f)
            {
                Destroy(_Destroy);
                off = false;
            }
        }
	}
}
