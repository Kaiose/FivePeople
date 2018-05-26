using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStageSelect : MonoBehaviour {

	public GameObject gameobject;
	public StageSelectManager selectmanager;
	public short stagenumber;
	public short starnumber;
	// Use this for initialization
	void Start () {
		selectmanager = gameobject.GetComponent<StageSelectManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		gameobject.SetActive(true);
		selectmanager.CurrentStage = stagenumber;
		selectmanager.CurrentStar = starnumber;
	}
}
