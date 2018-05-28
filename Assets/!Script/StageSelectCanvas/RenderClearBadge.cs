using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderClearBadge : MonoBehaviour {

	[SerializeField]
	private GameObject Badge;
	[SerializeField]
	private GameObject Star;

	private RenderStarNumber starnumber;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		starnumber = Star.GetComponent<RenderStarNumber>();

		if (starnumber.CurrentStar == 0)
		{
			Badge.SetActive(false);
		}
		else
			Badge.SetActive(true);
	}
}
