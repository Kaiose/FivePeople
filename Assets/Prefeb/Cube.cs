using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    // Use this for initialization
    public int type;
    public int x, y;
    public int flag;
  
    void Start()
    {
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
 
  
}
