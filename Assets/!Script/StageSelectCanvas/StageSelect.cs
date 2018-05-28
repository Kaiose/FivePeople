using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour {

	[SerializeField]
	private GameObject Entered;
	[SerializeField]

	private GameObject StageObject;
	[SerializeField]
	private GameObject StarObject;

	[SerializeField]
	private int StageNumber;
	[SerializeField]
	private int StarNumber;

	private RenderStageSelect stageselect;
	private RenderStarNumber renderStar;


	// Use this for initialization
	void Start () {
		stageselect = StageObject.GetComponent<RenderStageSelect>();
		renderStar = StarObject.GetComponent<RenderStarNumber>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		stageselect.CurrentStage = StageNumber;
		renderStar.CurrentStar = StarNumber;
		Entered.SetActive(true);
	}
}
