using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager{


    public int x, y;
    public bool state;
    public GameObject cube_object;

    public CubeManager()
    {
        state = true;
        cube_object = null;
    }
    public void ChangeCube(GameObject cube)
    {
        cube_object = cube;

        cube.GetComponent<Cube>().SetPositon(x, y);
    }
    public void Swap(CubeManager cm)
    {
       
        bool ts;
       
        ts = cm.state;
        GameObject temp = cm.cube_object;
        cm.cube_object = cube_object;
        cube_object = temp;
        cube_object.GetComponent<Cube>().SetPositon(x, y);
        if(cm.cube_object)cm.cube_object.GetComponent<Cube>().SetPositon(cm.x, cm.y);
        cm.state = state;
        state = ts;

    }
   
    public CubeManager(int i_type, int posx, int posy, GameObject new_cube)
    {
        x = posx;
        y = posy;
        state = true;
        cube_object = new_cube;
       
        new_cube.GetComponent<Cube>().InitCube(i_type, posx, posy, 1);
    }
}
