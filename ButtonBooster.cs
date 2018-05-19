using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBooster : MonoBehaviour {


	public bool boosterActivated;

	[SerializeField]
	private SpriteRenderer UnPressed;
	[SerializeField]
	private SpriteRenderer Pressed;

	// Use this for initialization
	void Start () {
		boosterActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(boosterActivated == false)
		{
			UnPressed.enabled = true;
			Pressed.enabled = false;
		}
		else
		{
			UnPressed.enabled = false;
			Pressed.enabled = true;
		}
	}


	private void OnMouseDown()
	{
		if (boosterActivated == false)
			boosterActivated = true;
		else
			boosterActivated = false;
	}
}
