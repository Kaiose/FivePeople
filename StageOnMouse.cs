using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
public class StageOnMouse : MonoBehaviour {

    private SpriteRenderer spriterenderer;
    public float Speed = 1.0f;
    private bool flag = false;

    [SerializeField]
    private MovingCanvas mc;
	// Use this for initialization
	void Start () {

        spriterenderer = GetComponent<SpriteRenderer>();

        Speed = 1.0f;
}
	
	// Update is called once per frame
	void Update () {
        if (spriterenderer.material.color.g <= 0)
        {
            flag = true;
        }
        if (spriterenderer.material.color.g >= 1)
            flag = false;
    }


    void OnMouseOver()
    {
        if (spriterenderer.sprite.name == "stage_unopened") return;
       if (!flag)
            spriterenderer.material.color = new Color(spriterenderer.material.color.r, spriterenderer.material.color.g - Speed * Time.deltaTime, spriterenderer.material.color.b);
       else
            spriterenderer.material.color = new Color(spriterenderer.material.color.r, spriterenderer.material.color.g + Speed * Time.deltaTime, spriterenderer.material.color.b);
    }

    void OnMouseExit()
    {
        spriterenderer.material.color = new Color(spriterenderer.material.color.r,1, spriterenderer.material.color.b);
    }

    void OnMouseDown()
    {
        mc.StartMove();
    }
}
