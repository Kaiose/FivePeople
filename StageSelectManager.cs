using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour {

	private SpriteRenderer[] spriteRenderer;
	
	private short CurrentStar;
	private short CurrentStage;
	private bool cleared;

	[SerializeField]
	private GameObject StageSelect;
	[SerializeField]
	private SpriteRenderer ClearBadge;
	

	// Use this for initialization
	void Start () {
		// 예전 플레이 기록에서 최고 기록 찾기
		CurrentStar = 3;
		cleared = true;

		// 스테이지 넘버 출력
		string stage = "stage";
		string stageNumber = CurrentStage.ToString();
		stage += stageNumber;
		StageSelectNumber(stage);

		// 별 갯수 출력
		string star = "star";
		string starNumber = CurrentStar.ToString();
		star += starNumber;
		StarInit(star);


		// true일 경우 클리어 뱃지 출력
		if (cleared == true)
			ClearBadge.enabled = true;
		else
			ClearBadge.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		
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

	public void StarInit(string star)
	{
		spriteRenderer = StageSelect.GetComponentsInChildren<SpriteRenderer>();

		foreach (SpriteRenderer child in spriteRenderer)
		{
			if(child.gameObject.name.CompareTo(star) == 0)
			{
				child.enabled = true;
			}
		}


	}
}
