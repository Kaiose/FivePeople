using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGoldSummon : MonoBehaviour
{

	public int RestGold;
	private bool mouseEntered;
	private int resultType;

	[SerializeField]
	private GameObject GoldText;
	[SerializeField]
	private GameObject Bt_Available;
	[SerializeField]
	private GameObject Bt_Pressed;
	[SerializeField]
	private GameObject Bt_disabled;
	[SerializeField]
	private GameObject NotEnough;
	[SerializeField]
	private GameObject Button;

	private SummonResult result;
	private TextMesh text;

	// Use this for initialization
	void Start()
	{
		text = GoldText.GetComponent<TextMesh>();

		Bt_Available.SetActive(false);
		Bt_disabled.SetActive(false);
		Bt_Pressed.SetActive(false);
		NotEnough.SetActive(false);
		mouseEntered = false;

		result = Button.GetComponent<SummonResult>();
	}

	// Update is called once per frame
	void Update()
	{
		text.text = RestGold.ToString();

		if (GoldCheck() == true)
		{
			if(mouseEntered == false)
				Bt_Available.SetActive(true);
			Bt_disabled.SetActive(false);
			NotEnough.SetActive(false);
		}
		else
		{
			Bt_Available.SetActive(false);
			Bt_disabled.SetActive(true);
			Bt_Pressed.SetActive(false);
			NotEnough.SetActive(true);
		}
	}

	public bool GoldCheck()
	{
		if (RestGold < 300)
			return false;
		else
			return true;
	}

	private void OnMouseEnter()
	{
		mouseEntered = true;

		if (GoldCheck() == true)
		{
			Bt_Available.SetActive(false);
			Bt_Pressed.SetActive(true);
		}

	}

	private void OnMouseDown()
	{
		if (GoldCheck() == true)
		{
			Summon();
		}
	}

	private void OnMouseExit()
	{
		mouseEntered = false;

		if (GoldCheck() == true)
		{
			Bt_Available.SetActive(true);
			Bt_Pressed.SetActive(false);
		}
	}

	public void Summon()
	{
		RestGold -= 300;
		result.ActiveResult();

		resultType = Random.Range(1, 5);
		result.resultType = resultType;
	}
}
