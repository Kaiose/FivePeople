using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonResult : MonoBehaviour {
	
	public int resultType;

	[SerializeField]
	private GameObject ResultCanvas;
	[SerializeField]
	private GameObject ResultBoost;
	[SerializeField]
	private GameObject ResultHeart;
	[SerializeField]
	private GameObject ResultTime;
	[SerializeField]
	private GameObject ResultCharacter;
	

	// Use this for initialization
	void Start () {
		resultType = 2;		
	}
	
	// Update is called once per frame
	void Update () {
		clearRender();
		ResultRender(resultType);
	}
	
	public void ActiveResult()
	{
		ResultCanvas.SetActive(true);
	}

	public void ResultRender(int type)
	{
		switch(type)
		{
			case 1:
				ResultBoost.SetActive(true);
				break;
			case 2:
				ResultHeart.SetActive(true);
				break;
			case 3:
				ResultTime.SetActive(true);
				break;
			case 4:
				ResultCharacter.SetActive(true);
				break;
		}

	}

	public void clearRender()
	{
		ResultBoost.SetActive(false);
		ResultHeart.SetActive(false);
		ResultTime.SetActive(false);
		ResultCharacter.SetActive(false);
	}
}
