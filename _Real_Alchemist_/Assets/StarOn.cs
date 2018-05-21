using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarOn : MonoBehaviour {
    /*
     *  HpBar와 거의 유사한 코드지만, 별이 줄어드는 것을 구현하기 위해서 새로 만들었다. 
     *  똑같이 bool을 이용해서 켰다가 껐다가 한다. 
    */
    Image fillIng;
    public float timeAmt = 10;
    float time;

    public GameObject star;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private bool onoff;


    void Start()
    {
        onoff = false;
        fillIng = this.GetComponent<Image>();
        time = timeAmt;
    }

    /*
        나중에 게임이 만들어 진다면, time을 score로 바꾸면 될 것.
    */
    void FixedUpdate()
    {
        if (onoff == true)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
                fillIng.fillAmount = time / timeAmt;
                if (fillIng.fillAmount < 0.952 && fillIng.fillAmount > 0.229)
                {
                    Destroy(star);
                    star1.SetActive(true);
                }
                if (fillIng.fillAmount < 0.229 && fillIng.fillAmount > 0.039)
                {
                    Destroy(star1);
                    star2.SetActive(true);
                }
                if (fillIng.fillAmount < 0.039)
                {
                    Destroy(star2);
                    star3.SetActive(true);
                }


            }
        }       
    }

    public void Off()
    {
        onoff = false;
    }

    public void On()
    {
        onoff = true;
    }
}
