using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovingCanvas : MonoBehaviour {


    Coroutine CanvasMove = null;

    public float Speed = 1.0f;

    int CanvasLength;
    private CanvasRenderer[] canvasrenderer;
    private Vector3[] CanvasDestinationPos;
    [SerializeField]
    private GameObject Canvas;
    [SerializeField]
    private float InitializePosition;
    

	// Use this for initialization
	void Start () {

        canvasrenderer = Canvas.GetComponentsInChildren<CanvasRenderer>();
        CanvasLength = canvasrenderer.Length;
        CanvasDestinationPos = new Vector3[CanvasLength];

        for (int i = 0; i < canvasrenderer.Length; i++)
        {
            CanvasDestinationPos[i] = canvasrenderer[i].transform.position;
        }
        foreach (CanvasRenderer child in canvasrenderer)
        {
            child.transform.position = new Vector3(child.transform.position.x + InitializePosition, child.transform.position.y);
            
        }
       
    }
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown("space"))
        //    StartCoroutine("Move");
	}

   public void StartMove()
    {
        StartCoroutine("Move");
    }

    public void InitializeCanvasPosition()
    {
        foreach (CanvasRenderer child in canvasrenderer)
        {
            child.transform.position = new Vector3(child.transform.position.x + InitializePosition, child.transform.position.y);

        }
    }

    IEnumerator Move()
    {
        float distance = 0.0f;
        bool flag = false;
        while (!flag)
        {
            distance -= Speed * Time.deltaTime;
            for(int i = 0; i < CanvasLength; i++)
            {
               canvasrenderer[i].transform.Translate(new Vector3(distance, 0));
                if (CanvasDestinationPos[CanvasLength-1].x >= canvasrenderer[CanvasLength-1].transform.position.x)
                {
                    flag = true;

                }
            }
            yield return null;
        }

    }

}

