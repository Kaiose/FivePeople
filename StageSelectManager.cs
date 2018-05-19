using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour {

	private SpriteRenderer[] spriteRenderer;

	[SerializeField]
	private short CurrentStage;
	[SerializeField]
	private GameObject StageSelect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		string stage = "stage";
		string stageNumber = CurrentStage.ToString();
		stage += stageNumber;
		print(stage);
		StageSelectNumber(stage);
	}
	
	public void StageSelectNumber(string stage)
	{
		spriteRenderer = StageSelect.GetComponentsInChildren<SpriteRenderer>();

		foreach (SpriteRenderer child in spriteRenderer)
		{
			if(child.gameObject.name.CompareTo(stage) == 0)
			{				
				child.enabled = true;
			}
		}
	}
}
