using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTicketSummon : MonoBehaviour
{

	public int RestTicket;
	private bool mouseEntered;
	private int resultType;

	[SerializeField]
	private GameObject TicketText;
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
		text = TicketText.GetComponent<TextMesh>();

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
		text.text = RestTicket.ToString();

		if (TicketCheck() == true)
		{
			if (mouseEntered == false)
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

	public bool TicketCheck()
	{
		if (RestTicket > 0)
			return true;
		else
			return false;
	}

	private void OnMouseEnter()
	{
		mouseEntered = true;

		if (TicketCheck() == true)
		{
			Bt_Available.SetActive(false);
			Bt_Pressed.SetActive(true);
		}

	}

	private void OnMouseDown()
	{
		if (TicketCheck() == true)
		{
			Summon();
		}
	}

	private void OnMouseExit()
	{
		mouseEntered = false;

		if (TicketCheck() == true)
		{
			Bt_Available.SetActive(true);
			Bt_Pressed.SetActive(false);
		}
	}

	public void Summon()
	{
		RestTicket--;
		result.ActiveResult();

		resultType = Random.Range(1, 5);
		result.resultType = resultType;
	}
}
