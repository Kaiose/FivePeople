using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour {
    

    [SerializeField]
    private Slider Loadingbar;
    [SerializeField]
    private float Speed;
	// Use this for initialization
	void Start () {
        Speed = 60.0f;
    }
	
	// Update is called once per frame
	void Update () {
        Loadingbar.value += Speed*Time.deltaTime;
        if (Loadingbar.value >= 100) Loadingbar.value = 0;
	}
}
