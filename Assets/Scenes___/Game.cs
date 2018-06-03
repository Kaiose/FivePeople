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
    int[] creat_arry = { max_row, max_row, max_row, max_row, max_row, max_row,  };
    
    CubeManager[,] list = new CubeManager[max_row, max_col];
    Buffer[] stack = new Buffer[max_col*max_row/3];
    Buffer[] del_buffer = new Buffer[max_col*max_row/3];
    Buffer create_buffer = new Buffer();
    int x1, y1,x2,y2;
    bool init_state = false;
    bool check_state = false;
    bool ok = true;
    bool jokejellyon = false;
    int s = 0;
    GameObject select_temp;

    public GameObject particle;
    public GameObject particleEffect;


    public Transform CoinDestroyPosition;
    Transform start;

    List<GameObject> CoinObject = new List<GameObject>();

    public bool boostCheck;


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
        bool t = false;
        while (tempj_right < max_col)
        {
            if (list[i, tempj_right].cube_object != null && list[i, j].cube_object.GetComponent<Cube>().type == list[i, tempj_right].cube_object.GetComponent<Cube>().type)
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
            if (list[i, tempj_left].cube_object != null && list[i, j].cube_object.GetComponent<Cube>().type == list[i, tempj_left].cube_object.GetComponent<Cube>().type)
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
            if (list[tempi_up, j].cube_object != null && list[i, j].cube_object.GetComponent<Cube>().type == list[tempi_up, j].cube_object.GetComponent<Cube>().type)
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
            if (list[tempi_down, j].cube_object != null && list[i, j].cube_object.GetComponent<Cube>().type == list[tempi_down, j].cube_object.GetComponent<Cube>().type)
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
        if (counti >= 3 || countj >= 3)
        {
            if (list[i, j].cube_object.GetComponent<Cube>().flag != -1)
            {
                list[i, j].cube_object.GetComponent<Cube>().flag = -1;
                stack[s].push(list[i, j]);
                t = true;
            }
            for (int temp = 1; temp < counti_up; temp++)
            {
                if (list[i + temp, j].cube_object.GetComponent<Cube>().flag != -1)
                {
                    list[i + temp, j].cube_object.GetComponent<Cube>().flag = -1;
                    stack[s].push(list[i + temp, j]);
                    t = true;
                }
            }
            for (int temp = 1; temp < counti_down; temp++)
            {
                if (list[i - temp, j].cube_object.GetComponent<Cube>().flag != -1)
                {
                    list[i - temp, j].cube_object.GetComponent<Cube>().flag = -1;
                    stack[s].push(list[i - temp, j]);
                    t = true;
                }
            }
            for (int temp = 1; temp < countj_right; temp++)
            {
                if (list[i, j + temp].cube_object.GetComponent<Cube>().flag != -1)
                {
                    list[i, j + temp].cube_object.GetComponent<Cube>().flag = -1;
                    stack[s].push(list[i, j + temp]);
                    t = true;
                }
            }
            for (int temp = 1; temp < countj_left; temp++)
            {
                if (list[i, j - temp].cube_object.GetComponent<Cube>().flag != -1)
                {
                    list[i, j - temp].cube_object.GetComponent<Cube>().flag = -1;
                    stack[s].push(list[i, j - temp]);
                    t = true;
                }
            }
            if (t == true)
            {
                s++;
                ok = false;
                return ok;
            }
        }
        return true;
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
    bool CheckCreate()
    {

        ok = true;
        while (create_buffer.top != -1)
        {
            CubeManager t = create_buffer.Pop();
            if (t.cube_object.GetComponent<Cube>().flag != -1)
                NodeCheck(t.x, t.y);
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
                particle = (GameObject)Instantiate(particleEffect, list[i, j].cube_object.transform.position, Quaternion.identity);

                CoinObject.Add(list[i, j].cube_object);

                if (list[i, j].cube_object.GetComponent<Cube>().tag == "objectjelly" && jokejellyon == true) sm.AddMainScore();
                //Destroy(list[i, j].cube_object);
                list[i, j].cube_object = null;//
                list[i, j].state = false;
                creat_arry[j]++;
                Destroy(particle, 0.5f);


            }
        }
    }
    

    bool Correct()
    {
        for (int j = 0; j < max_col; j++)
        {
            if (creat_arry[j] == 0) continue;
            for (int i = 0; i < max_row; i++)
            {

                if (list[i, j].state == true)
                {
                    continue;
                }
                else
                {
                    int pos = i;
                    i++;
                    while (i < max_row)
                    {
                        if (list[i, j].state == true)
                        {
                            list[pos, j].Swap(list[i, j]);
                            create_buffer.push(list[pos, j]);
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

        while (num <= s - 1)
        {
            while (stack[num].top != -1)
            {
                CubeManager temp = stack[num].Pop();
                if (temp != null)
                {

                    del_buffer[num].push(temp);


                    if (temp.x + 1 < max_row)
                    {
                        if (temp.cube_object.GetComponent<Cube>().type == list[temp.x + 1, temp.y].cube_object.GetComponent<Cube>().type)
                        {
                            if (list[temp.x + 1, temp.y].cube_object.GetComponent<Cube>().flag != -1)
                            {
                                list[temp.x + 1, temp.y].cube_object.GetComponent<Cube>().flag = -1;
                                stack[num].push(list[temp.x + 1, temp.y]);
                            }
                        }
                    }
                    if (temp.x - 1 >= 0)
                    {
                        if (temp.cube_object.GetComponent<Cube>().type == list[temp.x - 1, temp.y].cube_object.GetComponent<Cube>().type)
                        {
                            if (list[temp.x - 1, temp.y].cube_object.GetComponent<Cube>().flag != -1)
                            {
                                list[temp.x - 1, temp.y].cube_object.GetComponent<Cube>().flag = -1;
                                stack[num].push(list[temp.x - 1, temp.y]);
                            }
                        }
                    }
                    if (temp.y + 1 < max_col)
                    {
                        if (temp.cube_object.GetComponent<Cube>().type == list[temp.x, temp.y + 1].cube_object.GetComponent<Cube>().type)
                        {
                            if (list[temp.x, temp.y + 1].cube_object.GetComponent<Cube>().flag != -1)
                            {
                                list[temp.x, temp.y + 1].cube_object.GetComponent<Cube>().flag = -1;
                                stack[num].push(list[temp.x, temp.y + 1]);
                            }
                        }
                    }
                    if (temp.y - 1 >= 0)
                    {
                        if (temp.cube_object.GetComponent<Cube>().type == list[temp.x, temp.y - 1].cube_object.GetComponent<Cube>().type)
                        {
                            if (list[temp.x, temp.y - 1].cube_object.GetComponent<Cube>().flag != -1)
                            {
                                list[temp.x, temp.y - 1].cube_object.GetComponent<Cube>().flag = -1;
                                stack[num].push(list[temp.x, temp.y - 1]);
                            }
                        }
                    }
                }

            }
            num++;
        }
        num = 0;
        while (num <= s - 1)
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
    IEnumerator Create()
    {
        for (int j = 0; j < max_col; j++)
        {
            if (creat_arry[j] == 0) continue;
            while (creat_arry[j] > 0)
            {
                int posx = max_row - creat_arry[j];
                int type = Random.Range(0, 5);
                Vector3 position = new Vector3(-1.56f + j * 0.67f, 1.96f);
                list[posx, j] = new CubeManager(type, posx, j, Instantiate(cube[type], position, new Quaternion(0.0f, 0.0f, 0.0f, 1.0f)));
                creat_arry[j]--;
                create_buffer.push(list[posx, j]);
                yield return new WaitForSeconds(0.2f);
            }
        }
        check_state = true;
    }
    IEnumerator Init()
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
            yield return new WaitForSeconds(0.4f);
        }
        if (Check() == false)
        {
            KillCubes();
            Correct();
            StartCoroutine(Create());
        }
        init_state = true;
    }
 
    private void Awake()
    {
        init_state = false;
        StartCoroutine(Init());
    }
    void Start()
    {
        boostCheck = false;

        for (int i=0;i<max_row*max_col/3;i++)
        {
            stack[i] = new Buffer();
            del_buffer[i] = new Buffer();
        }
        create_buffer = new Buffer();
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

    public void BoostSet()
    {
        if (boostCheck == false)
            boostCheck = true;
        else
            boostCheck = false;
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
                }
                if (Input.GetMouseButtonDown(1))
                {
                    x2 = c.gameObject.GetComponent<Cube>().x;
                    y2 = c.gameObject.GetComponent<Cube>().y;
                    sm.LessTurn();
                }

            }
        }

        if (boostCheck == false)
        {
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
                    bool nc1 = NodeCheck(x1, y1);
                    bool nc2 = NodeCheck(x2, y2);
                    if (nc1 == true && nc2 == true)
                    {
                        SwapCube();
                        x1 = -1000;
                        x2 = -1000;
                        y1 = -1000;
                        y2 = -1000;
                        return false;
                    }

                    x1 = -1000;
                    x2 = -1000;
                    y1 = -1000;
                    y2 = -1000;
                    return true;
                }
            }
            return false;

        }

        else
            foreach (Collider2D c in col)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    x1 = c.gameObject.GetComponent<Cube>().x;
                    y1 = c.gameObject.GetComponent<Cube>().y;
                    int t = list[x1, y1].cube_object.GetComponent<Cube>().type;

                    for (int i = 0; i < max_row; i++)
                    {

                        for (int j = 0; j < max_col; j++)
                        {
                            if (list[i, j].cube_object.GetComponent<Cube>().type == t)
                            {


                                if (list[i, j].cube_object.GetComponent<Cube>().flag != -1)
                                {
                                    list[i, j].cube_object.GetComponent<Cube>().flag = -1;
                                    stack[s].push(list[i, j]);
                                }

                            }

                        }
                    }
                    s++;
                }
                return true;


                return false;
            }
        return false;
    }



    void Update ()
    {
        show.text = "포션들을 정리중이에요...";
        if (init_state == true)
        {
            if (check_state == true)
            {
                jokejellyon = false;                
                if (CheckCreate() == false)
                {
                    check_state = false;
                    Time.timeScale = 3.0f;
                    KillCubes();
                    Correct();
                    StartCoroutine(Create());                    
                }
                else
                {
                    show.text = "정리가 완료되었어요! \n START ";
                    if (Work() == true)
                    {
                        Time.timeScale = 1.0f;
                        jokejellyon = true;
                        check_state = false;
                        KillCubes();
                        Correct();
                        StartCoroutine(Create());
                        sm.AddScore(12);
                        so.AddStar();                        
                    }
                }
            }
        }

        for (int i = 0; i < CoinObject.Count; i++)
        {

            start = CoinObject[i].transform;

            CoinObject[i].transform.position = Vector2.Lerp(start.position, CoinDestroyPosition.position, Time.deltaTime);

            Debug.Log("코인 이동 들어옴");
            Debug.Log(CoinObject[i].transform.position.x);


            if (Vector3.Distance(CoinObject[i].transform.position, CoinDestroyPosition.position) < 0.1f)
            {
                
                //Particle
                particle = (GameObject)Instantiate(particleEffect, CoinDestroyPosition.position, Quaternion.identity);
                Destroy(CoinObject[i]);
                CoinObject.RemoveAt(i);
                Destroy(particle, 0.5f);
            }
        }
    }
}
