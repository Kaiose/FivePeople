using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAttendance : MonoBehaviour {

	[SerializeField]
	private new GameObject DestroyObject;
	[SerializeField]
	private SpriteRenderer RecieveCircle;

	private void Start()
	{
		RecieveCircle.enabled = false;
	}
	private void OnMouseEnter()
	{
		RecieveCircle.enabled = true;
	}

	private void OnMouseExit()
	{
		RecieveCircle.enabled = false;
	}

	private void OnMouseDown()
	{
		Destroy(DestroyObject, 0.2f);
	}
}
