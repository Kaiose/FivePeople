using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateZ : MonoBehaviour {

    private bool Flag = false;

    [SerializeField]
    private Image CurrentImage;
    [SerializeField]
    private float LeftRotate;
    [SerializeField]
    private float RightRotate;

    public float Speed = 5.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        CurrentImage.transform.Rotate(0, 0, -Speed); 
    }





}
