using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
                coin.transform.position = list[i, j].cube_object.transform.position;
                coin.SetActive(true);
                coin.transform.position = Vector3.MoveTowards(coin.transform.position, coinlocation.position , 30.0f * Time.deltaTime);
                if (coin.transform.position == coinlocation.position) Destroy(coin);
*/

public class Game : MonoBehaviour {
    public GameObject[] cube;
    public ScoreManager sm;
    public StarOn so;
    public Sprite Coin;
  
    public Text show;
    const int max_row = 9;
    const int max_col = 6;
    int[] creat_arry = { max_row, max_row, max_row, max_row, max_row, max_row, };
    
    CubeManager[,] list = new CubeManager[max_row, max_col];
    Buffer[] stack = new Buffer[max_col*max_row/3];
    Buffer[] del_buffer = new Buffer[max_col*max_row/3];
  
    int x1, y1,x2,y2;
    bool init_state = false;
    bool ok = true;
    int s = 0;
    GameObject select_temp;
    



    // Use this for initialization
    bool NodeCheck(int i,int j)
    {
        int tempj_right = j + 1;
        int tempj_left = j - 1;
        int tempi_up = i + 1;
        int tempi_down = i - 1;
        int countj = 0;
        int countj_right = 1;
        int countj_left = 1;
        int counti = 0;
        int counti_up = 1;
        int counti_down = 1;
       
        while (tempj_right < max_col)
        {
            if (list[i, j].cube_object.GetComponent<Cube>().type == list[i, tempj_right].cube_object.GetComponent<Cube>().type)
            {
                tempj_right++;
                countj_right++;
            }
            else
            {
                break;
            }
        }
        while (tempj_left >= 0)
        {
            if ( list[i, j].cube_object.GetComponent<Cube>().type == list[i, tempj_left].cube_object.GetComponent<Cube>().type)
            {
                tempj_left--;
                countj_left++;
            }
            else
            {
                break;
            }
        }
        countj = countj_left + countj_right - 1;
        while (tempi_up < max_row)
        {
            if (list[i, j].cube_object.GetComponent<Cube>().type == list[tempi_up, j].cube_object.GetComponent<Cube>().type)
            {
                tempi_up++;
                counti_up++;
            }
            else
            {
                break;
            }
        }
        while (tempi_down >= 0)
        {
            if (list[i, j].cube_object.GetComponent<Cube>().type == list[tempi_down, j].cube_object.GetComponent<Cube>().type)
            {
                tempi_down--;
                counti_down++;
            }
            else
            {
                break;
            }
        }
        counti = counti_up + counti_down - 1;
        if (counti >= 3||countj>=3)
        {
            list[i, j].cube_object.GetComponent<Cube>().flag = -1;
            stack[s].push(list[i, j]);
            for (int temp = 1; temp < counti_up; temp++)
            {
                list[i + temp, j].cube_object.GetComponent<Cube>().flag = -1;
                stack[s].push(list[i + temp, j]);
            }
            for (int temp = 1; temp < counti_down; temp++)
            {
                list[i - temp, j].cube_object.GetComponent<Cube>().flag = -1;
                stack[s].push(list[i - temp, j]);
            }
            for (int temp = 1; temp < countj_right; temp++)
            {
                list[i, j + temp].cube_object.GetComponent<Cube>().flag = -1;
                stack[s].push(list[i, j + temp]);
            }
            for (int temp = 1; temp < countj_left; temp++)
            {
                list[i, j - temp].cube_object.GetComponent<Cube>().flag = -1;
                stack[s].push(list[i, j - temp]);
            }
            s++;
            ok = false;
        }
        return ok;
    }

    bool Check()
    {
        ok = true; s = 0;
        for(int i=0;i<max_row;i++)
        {
           
            for(int j=0; j<max_col;j++)
            {
                NodeCheck(i, j); 
            }
        }
        return ok;
    }

    void DelNode(int i,int j)
    {
        if (list[i, j].cube_object)
        {
            if (list[i, j].cube_object.GetComponent<Cube>().flag == -1)
            {

                list[i, j].cube_object.GetComponent<Cube>().ChangeSprite(Coin);
               // Destroy(list[i, j].cube_object);
                list[i, j].cube_object = null;//
                list[i, j].state = false;
                creat_arry[j]++;
            }
        }
    }
    

    bool Correct()
    {
        for(int j=0;j<max_col;j++)
        {
            for(int i=0;i<max_row;i++)
            {
                
                if(list[i,j].state==true)
                {
                    continue;
                }
                else
                {
                    int pos = i;
                    i++;
                    while(i<max_row)
                    {
                        if(list[i,j].state==true)
                        {
                            list[pos, j].Swap(list[i, j]);
                            pos++;
                            i++;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
        }
        return true;
    }

    public bool KillCubes()
    {
        int num = 0;
        
        while (num<=s)
        {
            while (stack[num].top != -1)
            {
                CubeManager temp = stack[num].Pop();
                if (temp != null)
                {
                  
                    del_buffer[num].push(temp);
                    
                    if ((temp.x + 1 < max_row) && (temp.cube_object.GetComponent<Cube>().type == list[temp.x + 1, temp.y].cube_object.GetComponent<Cube>().type))
                    {

                        if (list[temp.x + 1, temp.y].cube_object.GetComponent<Cube>().flag != -1)
                        {
                            list[temp.x + 1, temp.y].cube_object.GetComponent<Cube>().flag = -1;
                            stack[num].push(list[temp.x + 1, temp.y]);
                        }
                    }
                    else if ((temp.x - 1 >= 0) && (temp.cube_object.GetComponent<Cube>().type == list[temp.x - 1, temp.y].cube_object.GetComponent<Cube>().type))
                    {
                        if (list[temp.x - 1, temp.y].cube_object.GetComponent<Cube>().flag != -1)
                        {
                            list[temp.x - 1, temp.y].cube_object.GetComponent<Cube>().flag = -1;
                            stack[num].push(list[temp.x - 1, temp.y]);
                        }
                    }
                    else if ((temp.y + 1 < max_col) && (temp.cube_object.GetComponent<Cube>().type == list[temp.x, temp.y + 1].cube_object.GetComponent<Cube>().type))
                    {
                        if (list[temp.x, temp.y + 1].cube_object.GetComponent<Cube>().flag != -1)
                        {
                            list[temp.x, temp.y + 1].cube_object.GetComponent<Cube>().flag = -1;
                            stack[num].push(list[temp.x, temp.y + 1]);
                        }
                    }
                    else if ((temp.y - 1 >= 0) && (temp.cube_object.GetComponent<Cube>().type == list[temp.x, temp.y - 1].cube_object.GetComponent<Cube>().type))
                    {
                        if (list[temp.x, temp.y - 1].cube_object.GetComponent<Cube>().flag != -1)
                        {
                            list[temp.x, temp.y - 1].cube_object.GetComponent<Cube>().flag = -1;
                            stack[num].push(list[temp.x, temp.y - 1]);
                        }
                    }
                }
               
            }
            num++;
        }
        num = 0;
        while (num <=s)
        {
            while (del_buffer[num].top != -1)
            {
                CubeManager del_temp = del_buffer[num].Pop();
                if (del_temp != null)
                {
                    DelNode(del_temp.x, del_temp.y);
                }
            }
            num++;
        }
        s = 0;
        return true;
    }
   
    IEnumerator Creat()
    {
        for (int i = 0; i < max_row; i++)
        {
            for (int j = 0; j < max_col; j++)
            { 
                
                if(creat_arry[j] > 0)
                {
                    int posx = max_row - creat_arry[j];
                    int type = Random.Range(0, 5);
                    Vector3 position = new Vector3(-1.56f + j * 0.67f, 1.96f);
                    list[posx,j]= new CubeManager(type,posx,j,Instantiate(cube[type], position, new Quaternion(0.0f, 0.0f, 0.0f, 1.0f)));                
                    creat_arry[j]--;
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
        init_state = true;
    }
 
    private void Awake()
    {
        init_state = false;
        StartCoroutine(Creat());
    }
    void Start()
    {


      for(int i=0;i<max_row*max_col/3;i++)
        {
            stack[i] = new Buffer();
            del_buffer[i] = new Buffer();
        }
        x1 = -1000;
        x2 = -1000;
        y1 = -1000;
        y2 = -1000;
    }
    void SwapCube()
    {
        GameObject temp = list[x1, y1].cube_object;
        list[x1, y1].cube_object = list[x2, y2].cube_object;
        list[x2, y2].cube_object = temp;
        list[x1, y1].cube_object.GetComponent<Cube>().SetPositon(list[x1, y1].x, list[x2, y2].y);
        list[x2, y2].cube_object.GetComponent<Cube>().SetPositon(list[x2, y2].x, list[x2, y2].y);
        Vector3 pos = list[x1, y1].cube_object.transform.position;
        list[x1, y1].cube_object.transform.position = list[x2, y2].cube_object.transform.position;
        list[x2, y2].cube_object.transform.position = pos;
    }
    bool Work()
    {
        Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (col.Length > 0)
        {
            foreach (Collider2D c in col)
            { 
                if (Input.GetMouseButtonDown(0))
                {
                    x1 = c.gameObject.GetComponent<Cube>().x;
                    y1 = c.gameObject.GetComponent<Cube>().y;
                    sm.LessTurn();
                }
                if (Input.GetMouseButtonDown(1))
                {
                    x2 = c.gameObject.GetComponent<Cube>().x;
                    y2 = c.gameObject.GetComponent<Cube>().y;
                }

            }
        }
        if (x1 != -1000 && x2 != -1000 && y1 != -1000 && y2 != -1000)
        {
            if (x2 - x1 > 1 || x2 - x1 < -1 || y2 - y1 > 1 || y2 - y1 < -1)
            { 
                x1 = -1000;
                x2 = -1000;
                y1 = -1000;
                y2 = -1000;
                return false;
            }
            else
            {
                SwapCube(); 
                if (NodeCheck(x1,y1)==true&&NodeCheck(x2,y2)==true)
                {
                    SwapCube();        
                    x1 = -1000; x2 = -1000; y1 = -1000; y2 = -1000;                   
                    return false;
                }
                x1 = -1000; x2 = -1000; y1 = -1000; y2 = -1000;
                return true;
            }
        }
        return false;
    }



    void Update ()
    {
        if (init_state == true)
        {
            show.text = "Wait";
            if (Check() == false)
            {
                if (KillCubes() == true)
                {
                    if (Correct() == true)
                    {
                        init_state = false;
                        StartCoroutine(Creat());
                    }
                    sm.AddScore(3);
                    so.AddStar();
                }
            }
            else
            {
                show.text = "START";
                Work();

            }
        }
    }
}
