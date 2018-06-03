using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{

	[SerializeField]
	private GameObject Entered;
	[SerializeField]
	private GameObject MoveObject;
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
	private MovingStageCanvas stageCanvas;

	// Use this for initialization
	void Start()
	{
		stageCanvas = MoveObject.GetComponent<MovingStageCanvas>();
		stageselect = StageObject.GetComponent<RenderStageSelect>();
		renderStar = StarObject.GetComponent<RenderStarNumber>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnMouseDown()
	{
		if (stageCanvas.UiOn == false)
		{
			stageselect.CurrentStage = StageNumber;
			renderStar.CurrentStar = StarNumber;
			Entered.SetActive(true);
			stageCanvas.StartMoveLeft();

			stageCanvas.UiOn = true;
		}

	}
}
