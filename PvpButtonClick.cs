using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpButtonClick : MonoBehaviour {

    bool ButtonOn = true;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite SpriteOn;
    [SerializeField]
    private Sprite SpriteOff;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
        spriteRenderer.sprite = SpriteOn;
    }

    private void OnMouseDown()
    {
        spriteRenderer.sprite = SpriteOff;
    }
}
