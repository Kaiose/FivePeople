using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lowhpBar : MonoBehaviour
{
    /*
     * 빨피가 되었을 때 작동되는 코드이다. 
     * 여기서 시간이 다 되서 죽었을 시, GameOver창을 띄워준다. 
    */
    Image fillIng;
    public float timeAmt = 10;
    float time;
    bool OnOff;

    // 체력바가 다 달면 불러오는 것.
    public GameObject gameover;

    // 세팅창 동작그만
    public GameObject setting;

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

            if(fillIng.fillAmount == 0)
            {
                gameover.SetActive(true);
                Destroy(setting);
            }
        }
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
