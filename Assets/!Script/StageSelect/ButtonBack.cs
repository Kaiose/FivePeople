using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
public class ButtonBack : MonoBehaviour
{
	[SerializeField]
	private new GameObject DestroyObject;
	[SerializeField]
	private SpriteRenderer UnPressed;
	[SerializeField]
	private SpriteRenderer Pressed;
    [SerializeField]
    private SceneChange SceneChange;
	// 버튼 기본상태  false, 바뀔때는 true
	bool buttonPressed = false;

	// Use this for initialization
	void Start()
	{
		UnPressed.enabled = true;
		Pressed.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (buttonPressed == false)
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

	private void OnMouseEnter()
	{
		buttonPressed = true;
	}

	private void OnMouseExit()
	{
		buttonPressed = false;
	}

	private void OnMouseDown()
	{
        SceneChange.CallScene();
		buttonPressed = false;
	}


}
