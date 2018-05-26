using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFriendScoreSummon : MonoBehaviour
{

	public int RestFriendScore;
	private bool mouseEntered;
	private int resultType;

	[SerializeField]
	private GameObject FriendText;
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
		text = FriendText.GetComponent<TextMesh>();

		Bt_Available.SetActive(false);
		Bt_disabled.SetActive(false);
		Bt_Pressed.SetActive(false);
		mouseEntered = false;
		NotEnough.SetActive(false);

		result = Button.GetComponent<SummonResult>();
	}

	// Update is called once per frame
	void Update()
	{
		text.text = RestFriendScore.ToString();

		if (FriendScoreCheck() == true)
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

	public bool FriendScoreCheck()
	{
		if (RestFriendScore < 500)
			return false;
		else
			return true;
	}

	private void OnMouseEnter()
	{
		mouseEntered = true;

		if (FriendScoreCheck() == true)
		{
			Bt_Available.SetActive(false);
			Bt_Pressed.SetActive(true);
		}

	}

	private void OnMouseDown()
	{
		if (FriendScoreCheck() == true)
		{
			Summon();
		}
	}

	private void OnMouseExit()
	{
		mouseEntered = false;

		if (FriendScoreCheck() == true)
		{
			Bt_Available.SetActive(true);
			Bt_Pressed.SetActive(false);
		}
	}

	public void Summon()
	{
		RestFriendScore -= 500;
		result.ActiveResult();

		resultType = Random.Range(1, 5);
		result.resultType = resultType;
	}
}
