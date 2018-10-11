using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    float speed = 0.1f;
    bool moving = false;

    int chaseX; // 0 이면 X축으로, 1 이면 Z축으로 추적

    float toX;
    float toZ;

    float gridX = 10;
    float gridZ = 10;

    private GameObject playerObject;

    Vector3 towardPos;

   void compare()
    {
        print("compare");

        Vector3 playerPos = playerObject.transform.position;

        // 가야 할 x 좌표
        if(playerPos.x < transform.position.x)
        {
            toX = transform.position.x - gridX;
        }
        else if(playerPos.x > transform.position.x)
        {
            toX = transform.position.x + gridX;
        }
        else if(playerPos.x == transform.position.x)
        {
            toX = transform.position.x;
        }

        // 가야 할 Z 좌표
        if (playerPos.z < transform.position.z)
        {
            toZ = transform.position.z - gridZ;
        }
        else if (playerPos.z > transform.position.z)
        {
            toZ = transform.position.z + gridZ;
        }
        else if (playerPos.z == transform.position.z)
        {
            toZ = transform.position.z;
        }

        towardPos = new Vector3(toX, 0, toZ);
    }

	// Use this for initialization
	void Start () {
        playerObject = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        if (moving == false)
        {
            compare();
            chaseX = Random.Range(0, 2);
            moving = true;
        }
        else
        {
            if (chaseX == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(toX, 0, transform.position.z), speed);

                if (transform.position.x > toX - 0.1 && transform.position.x < toX + 0.1)
                {
                    transform.position = new Vector3(toX, 0.5f, transform.position.z);
                    moving = false;
                }
            }
            else if (chaseX == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0, toZ), speed);

                if (transform.position.z > toZ - 0.1 && transform.position.z < toZ + 0.1)
                {
                    transform.position = new Vector3(transform.position.x, 0.5f, toZ);
                    moving = false;
                }
            }
        }
    }
}
