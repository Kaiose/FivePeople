using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnOff : MonoBehaviour {
    bool ButtonOn = true;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite SpriteOn;
    [SerializeField]
    private Sprite SpriteOff;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseUp()
    {

    }

    private void OnMouseDown()
    {
        if (ButtonOn)
        {
            spriteRenderer.sprite = SpriteOff;
            ButtonOn = false;
        }
        else
        {
            spriteRenderer.sprite = SpriteOn;
            ButtonOn = true;
        }
    }

}
