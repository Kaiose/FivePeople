using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEffect : MonoBehaviour {

    private SpriteRenderer sr;
    private string SpriteName;
    private Color SourceColorAlpha;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        SourceColorAlpha= sr.color;

	}
	
	// Update is called once per frame
	void Update () {
      
        
       
    }

    void OnMouseDown()
    {

        SourceColorAlpha.a = 0.5f;
        sr.color = SourceColorAlpha;
    }

    void OnMouseExit()
    {
        
    }

}
