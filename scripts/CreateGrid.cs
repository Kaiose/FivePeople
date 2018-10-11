using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour {

    [SerializeField]
    private GameObject firstGridObject;
    [SerializeField]
    private GameObject secondGridObject;

    [SerializeField]
    private int row = 5;
    [SerializeField]
    private int col = 5;

    int x = 0;
    int z = 0;
    int number = 1;

    bool flag = false;

    
	// Use this for initialization
	void Start () {

        GameObject created;

        //int[,] gridIndex = new int[row, col];

		for(int r = 0; r < row; r++)
        {
            for(int c = 0; c < col; c++)
            {
                created = null;

                if (flag == false)
                {
                    created =  Instantiate(firstGridObject, new Vector3(x, 0, z), Quaternion.identity);
                    created.transform.parent = this.transform;
                    created.GetComponent<GridManager>().SetIndex(number);

                    flag = true;
                }
                else if (flag == true)
                {
                    created = Instantiate(secondGridObject, new Vector3(x, 0, z), Quaternion.identity);
                    created.transform.parent = this.transform;
                    created.GetComponent<GridManager>().SetIndex(number);

                    flag = false;
                }
                x += 10;
                number++;
            }
            z += 10;
            x = 0;

            if (col % 2 == 0)
            {
                if (flag == false)
                    flag = true;
                else
                    flag = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
