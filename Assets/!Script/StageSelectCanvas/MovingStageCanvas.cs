using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStageCanvas : MonoBehaviour {

	private float nowX;

	[SerializeField]
	private int signed;
	[SerializeField]
	private float Speed;

	[HideInInspector]
	public bool UiOn;


    private Vector3 origin;
	// Use this for initialization
	void Start() {
		UiOn = false;
		signed = -1;
        origin = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void StartMoveLeft()
	{
		StartCoroutine("MoveToLeft");
	}

	IEnumerator MoveToLeft()
	{
		bool moveCheckLeft = true;
		signed = -1;
		this.gameObject.transform.Translate(1000.0f, 0.0f, 0.0f);

		while (moveCheckLeft)
		{
			this.gameObject.transform.Translate(signed * Speed * Time.deltaTime, 0.0f, 0.0f);

			nowX = this.gameObject.transform.position.x;

			if (nowX <= 300)
			{
				moveCheckLeft = false;
				//this.gameObject.transform.position = new Vector3(545.0f, 969.0f, 0.0f);
			}

			yield return null;
		}
	}

	public void StartMoveRight()
	{
		StartCoroutine("MoveToRight");
	}

	IEnumerator MoveToRight()
	{
		bool moveCheckRight = true;
		signed = 1;

		while (moveCheckRight)
		{
			this.gameObject.transform.Translate(signed * Speed * Time.deltaTime, 0.0f, 0.0f);

			nowX = this.gameObject.transform.position.x;

			if (nowX >= 1600)
			{
				moveCheckRight = false;
			}
			yield return null;
		}
	}

	public void UiSet()
	{
		UiOn = true;
	}

	public void UiDontSet()
	{
		UiOn = false;
	}
}
