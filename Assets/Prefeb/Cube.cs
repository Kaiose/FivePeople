using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    // Use this for initialization
    public int type;
    public int x, y;
    public int flag;
    public SpriteRenderer sr;
    public BoxCollider2D collider;
    public Rigidbody2D rd;
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        flag = 1;
    }
    public void InitCube(int i_type,int posx,int posy,int i_flag)
    {
        type = i_type;
        x = posx;
        y = posy;
        flag = i_flag;
    }
    
    public void SetPositon(int posx, int posy)
    {
        x = posx;
        y = posy;
    }

    public void ChangeSprite(Sprite temp)
    {
        sr.sprite = temp;
        collider.enabled = false;
        Destroy(rd);
    }
  
}
