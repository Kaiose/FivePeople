using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool moving = false;
    public float speed = 0.5f;
    
    float toX = 0;
    float toZ = 0;

    float gridX = 10;
    float gridZ = 10;

    public void SetToX(float x)
    {
        toX = x;
    }

    public void SetToZ(float z)
    {
        toZ = z;
    }

    public void SetIdle()
    {
        moving = false;
    }

    public void SetMoving()
    {
        moving = true;
    }

    public void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8) == true)
        {
            SetMoving();
            toZ += gridZ;
            //towardPlusZ = true;
        }

        if (Input.GetKeyDown(KeyCode.Keypad5) == true)
        {
            SetMoving();
            toZ -= gridZ;
            //towardPlusZ = false;
        }

        if (Input.GetKeyDown(KeyCode.Keypad4) == true)
        {
            SetMoving();
            toX -= gridX;
            //towardPlusX = false;
        }

        if (Input.GetKeyDown(KeyCode.Keypad6) == true)
        {
            SetMoving();
            toX += gridX;
            // towardPlusX = true;
        }

        if (Input.GetKeyDown(KeyCode.Keypad7) == true)
        {
            SetMoving();
            toZ += gridZ;
            toX -= gridX;
        }

        if (Input.GetKeyDown(KeyCode.Keypad9) == true)
        {
            SetMoving();
            toZ += gridZ;
            toX += gridX;
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) == true)
        {
            SetMoving();
            toZ -= gridZ;
            toX -= gridX;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3) == true)
        {
            SetMoving();
            toZ -= gridZ;
            toX += gridX;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moving == false)
        {
            PlayerMove();
        }
        else if (moving == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(toX, 0.5f, toZ), speed);
            if (transform.position.x == toX && transform.position.z == toZ)
                SetIdle();
        }
    }

}
