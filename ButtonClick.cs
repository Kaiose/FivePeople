using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour {
	[SerializeField]
	private GameObject Canvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private void OnMouseDown()
	{
		Canvas.SetActive(true);
	}
}
