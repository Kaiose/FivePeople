using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour {

    public GameObject DestroyCanvas;
    public GameObject ActiveCanvas;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseUp()
    {
       Debug.Log("마우스 클릭 됨");
        DestroyCanvas.SetActive(false);
        ActiveCanvas.SetActive(true);
       
    }
}
