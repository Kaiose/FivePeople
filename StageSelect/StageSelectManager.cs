using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour {

	private SpriteRenderer[] spriteRenderer;
	
	[HideInInspector]
	public short CurrentStar;
	[HideInInspector]
	public short CurrentStage;
	private bool cleared;

	[SerializeField]
	private GameObject StageSelect;
	[SerializeField]
	private SpriteRenderer ClearBadge;
	

	// Use this for initialization
	void Start () {
		CurrentStage = 1;
		// CurrentStar = (short)Random.Range(0, 4);
		cleared = false;
	}

	// Update is called once per frame
	void Update () {
		// 예전 플레이 기록에서 최고 기록 찾기

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


		// 별이 하나라도 많으면 cleared를 true로 바꾸기
		if (CurrentStar == 0)
			cleared = false;
		else
			cleared = true;

		// true일 경우 클리어 뱃지 출력
		if (cleared == true)
			ClearBadge.enabled = true;
		else
			ClearBadge.enabled = false;
		
	}
	
	public void StageSelectNumber(string stage)
	{
		spriteRenderer = StageSelect.GetComponentsInChildren<SpriteRenderer>();

		foreach (SpriteRenderer child in spriteRenderer)
		{
			if (child.CompareTag("StageNumber"))
			{
				if (child.gameObject.name.CompareTo(stage) == 0)
				{
					child.enabled = true;
				}
				else
				{
					child.enabled = false;
				}
			}
		}
	}

	public void StarInit(string star)
	{
		spriteRenderer = StageSelect.GetComponentsInChildren<SpriteRenderer>();

		foreach (SpriteRenderer child in spriteRenderer)
		{
			if (child.CompareTag("StarNumber"))
			{
				if (child.gameObject.name.CompareTo(star) == 0)
				{
					child.enabled = true;
				}
				else
				{
					child.enabled = false;
				}
			}
		}


	}
}
