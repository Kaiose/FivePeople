using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRegen : MonoBehaviour {

    [SerializeField]
    private GameObject enemyObject;

    public int time = 360;
    public int timeCount;
	// Use this for initialization
	void Start () {
        timeCount = time;
        RegenStart();
	}
	
	// Update is called once per frame
	void Update () {

        timeCount--;

        if (timeCount < 0)
        {
            RegenStart();
            timeCount = time;
        }

    }

    void RegenStart()
    {
        GameObject[] Grid_List = GameObject.FindGameObjectsWithTag("Grid");
        int num = Random.Range(0, Grid_List.Length);
        /* 
         foreach (GameObject Grid_Object in Grid_List)
         {
             if(Grid_Object.GetComponent<GridManager>().somethingStay == false)
             {
                 float gridPosX = Grid_Object.transform.position.x;
                 float gridPosZ = Grid_Object.transform.position.z;

                 Instantiate(enemyObject, new Vector3(gridPosX, 0, gridPosZ), Quaternion.identity);
                 break;
             }
         }
         */
        if (Grid_List[num].GetComponent<GridManager>().somethingStay == false)
        {
            float gridPosX = Grid_List[num].transform.position.x;
            float gridPosZ = Grid_List[num].transform.position.z;

            Instantiate(enemyObject, new Vector3(gridPosX, 0, gridPosZ), Quaternion.identity);
        }
    }
}
