using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManager;
public class MovingCanvas : MonoBehaviour {

    public float Speed = 1.0f;

    private Vector3 CanvasDestinationPos;
    [SerializeField]
    private Canvas Object;
    [SerializeField]
    private float InitializePosition;
    

	// Use this for initialization
	void Start () {
        CanvasDestinationPos = new Vector3(Object.transform.position.x, Object.transform.position.y);
        Object.transform.Translate(InitializePosition, 0, 0);
        
     

     //   Canvas.transform.Translate(InitializePosition, 0, 0);
       
    }
	
	// Update is called once per frame
	void Update () {

	}

   public void StartMove()
    {
        StartCoroutine("Move");
    }

    public void InitializeCanvasPosition()
    {
       Object.transform.Translate(InitializePosition, 0, 0);
    }

    IEnumerator Move()
    {
        float distance = 0.0f;
        bool flag = false;
        while (!flag)
        {
            distance -= Speed * Time.deltaTime;

            Object.transform.Translate(distance, 0, 0);

            if (Object.transform.position.x <= CanvasDestinationPos.x)
                flag = true;

            yield return null;
        }

    }

}

