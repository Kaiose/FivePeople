using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttendanceManager : MonoBehaviour
{

	private SpriteRenderer[] spriteRenderer;


	[SerializeField]
	private GameObject AttendanceTable;
	[SerializeField]
	private int today;

	[SerializeField]
	private Sprite HeartToday;
	[SerializeField]
	private Sprite InfinityToday;
	[SerializeField]
	private Sprite SummonToday;
	[SerializeField]
	private Sprite GoldToday;
	[SerializeField]
	private Sprite BoostToday;

	// 날짜를 받아서 0이면 수령안했음, 1이면 수령함 혹은 예정
	private int[] dateStatus = new int[32];

	private string date;
	private string dateNumber;
	private int item;

	// Use this for initialization
	void Start()
	{
		spriteRenderer = AttendanceTable.GetComponentsInChildren<SpriteRenderer>();

		// dateStatus값을 임의로 지정
		for (int i = 0; i < 32; i++)
		{
			dateStatus[i] = Random.Range(0, 2);
		}

		// 각 날짜별 상황을 확인하고 스프라이트를 바꿈
		for (int i = 1; i < today; i++)
		{
			date = "date";
			dateNumber = i.ToString();
			date += dateNumber;
			if (dateStatus[i] == 0)
			{
				AttendanceInit(date);
			}
		}


		// 오늘의 스프라이트를 바꿈
		item = today % 7;
		date = "date";
		dateNumber = today.ToString();
		date += dateNumber;

		TodayInit(date, item);

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void AttendanceInit(string date)
	{
		foreach (SpriteRenderer child in spriteRenderer)
		{
			if (child.gameObject.name.CompareTo(date) == 0)
			{
				Color color = child.color;
				color.a = 0.2f;
				child.color = color;
			}
		}
	}

	public void TodayInit(string date, int item)
	{
		foreach (SpriteRenderer child in spriteRenderer)
		{
			if (child.gameObject.name.CompareTo(date) == 0)
			{
				SpriteRenderer currentSprite;

				currentSprite = child.gameObject.GetComponent<SpriteRenderer>();


				// 여기에 아이템 수령 코드 추가 할것
				switch (item)
				{
					case 0:
						currentSprite.sprite = GoldToday;
						break;
					case 1:
						currentSprite.sprite = HeartToday;
						break;

					case 2:
						currentSprite.sprite = InfinityToday;

						break;
					case 3:
						currentSprite.sprite = SummonToday;
						break;

					case 4:
						currentSprite.sprite = GoldToday;
						break;
					case 5:
						currentSprite.sprite = BoostToday;
						break;
					case 6:
						currentSprite.sprite = HeartToday;
						break;
				}
			}
		}

	}
}
