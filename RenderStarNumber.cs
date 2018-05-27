using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderStarNumber : MonoBehaviour {

	public int CurrentStar;

	[SerializeField]
	private GameObject StarObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		string star = "star";
		string starNumber = CurrentStar.ToString();
		star += starNumber;
		StageStarNumber(star);
	}

	public void StageStarNumber(string star)
	{
		StarClear();
		StarObject.transform.Find(star).gameObject.SetActive(true);
	}

	public void StarClear()
	{
		for(int i = 0; i <= 3; i++)
		{
			string star = "star";
			string starNumber = i.ToString();
			star += starNumber;
			StarObject.transform.Find(star).gameObject.SetActive(false);
		}
	}
}
