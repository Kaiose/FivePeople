using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGameStart : MonoBehaviour {

	[SerializeField]
	private SpriteRenderer StartCircle;

	private ButtonBooster booster;

	bool boosted = false;

	// Use this for initialization
	void Start () {
		StartCircle.enabled = false;
		booster = GetComponent<ButtonBooster>();
	}
	
	// Update is called once per frame
	void Update () {

		//부스터가 켜졌는지 꺼졌는지 검사
		//booster.boosterActivated = boosted;
	}

	private void OnMouseEnter()
	{
		StartCircle.enabled = true;
	}

	private void OnMouseExit()
	{
		StartCircle.enabled = false;
	}

	private void OnMouseDown()
	{
		/*	boosted를 확인하고 게임 시작	 */
	}
}
