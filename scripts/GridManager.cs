using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    int gridIndex = 0;

    [HideInInspector]
    public bool somethingStay = false;

    bool mouseOver = false;

    public void SetIndex(int number)
    {
        gridIndex = number;
    }

    public int GetIndex()
    {
        return gridIndex;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision col)
    {
        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Enemy"))
        {
            somethingStay = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Enemy"))
        {
            somethingStay = false;
        }
    }

    private void OnMouseOver()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }

    private void OnMouseDown()
    {
        if(mouseOver == true)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            playerObject.GetComponent<PlayerManager>().SetToX(transform.position.x);
            playerObject.GetComponent<PlayerManager>().SetToZ(transform.position.z);
            playerObject.GetComponent<PlayerManager>().SetMoving();
        }

    }

}
