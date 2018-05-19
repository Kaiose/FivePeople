using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lowhpBar : MonoBehaviour
{

    Image fillIng;
    public float timeAmt = 10;
    float time;
    bool OnOff;

    // 체력바가 다 달면 불러오는 것.
    GameObject gameover;

    void Start()
    {
        OnOff = true;
        fillIng = this.GetComponent<Image>();
        time = timeAmt;
    }

    void FixedUpdate()
    {
        if (OnOff == true)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                fillIng.fillAmount = time / timeAmt;
            }
        }
        // 불러오기 넣을 자리
    }


    /*
     세팅창을 켜면 체력게이지가 줄어드는 것을 막기 위해서. 
    */
    public void StopThis()
    {
        OnOff = false;
    }
    /*
     다시 켜지게
    */
    public void StartThis()
    {
        OnOff = true;
    }
}
