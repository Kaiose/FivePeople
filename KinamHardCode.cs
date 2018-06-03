using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinamHardCode : MonoBehaviour {

    private CircleCollider2D[] ChildCollider;


    [SerializeField]
    public GameObject StageGroup;

	// Use this for initialization
	void Start () {

        ChildCollider = StageGroup.GetComponentsInChildren<CircleCollider2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void EnableCollider()
    {
        foreach (CircleCollider2D child in ChildCollider)
            child.enabled = true;
    }

    public void DisableCollder()
    {
        foreach (CircleCollider2D child in ChildCollider)
            child.enabled = false;
    }
}
