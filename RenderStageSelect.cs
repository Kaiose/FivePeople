using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RenderStageSelect : MonoBehaviour {
	
	public int CurrentStage;

	[SerializeField]
	private GameObject StageObject;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		string stage = "stage";
		string stageNumber = CurrentStage.ToString();
		stage += stageNumber;
		StageSelectNumber(stage);

	}

	public void StageSelectNumber(string stage)
	{
		NumberClear();
		StageObject.transform.Find(stage).gameObject.SetActive(true);
	}

	public void NumberClear()
	{
		for(int i = 1; i <= 11; i++)
		{
			string stage = "stage";
			string number = i.ToString();
			stage += number;
			StageObject.transform.Find(stage).gameObject.SetActive(false);
		}
	}
}
