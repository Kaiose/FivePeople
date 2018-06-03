using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarOn : MonoBehaviour {
    /*
     *  HpBar와 거의 유사한 코드지만, 별이 줄어드는 것을 구현하기 위해서 새로 만들었다. 
     *  똑같이 bool을 이용해서 켰다가 껐다가 한다. 
    */
    public static StarOn instance;

    Image fillIng;
    // 점수에 따라 늘어나는 게이지의 량
    public static float coinHP;
    public GameObject star;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private bool onoff;
    int coinNumber;

    void Start()
    {
        onoff = false;
        fillIng = this.GetComponent<Image>();

        fillIng.fillAmount = 0.0f;
        coinHP = 0.0f;
    }

    /*
        나중에 게임이 만들어 진다면, time을 score로 바꾸면 될 것.
    */

    void Awake()
    {
        if (!instance)
            instance = this;
    }

    public void AddStar()
    {
        coinHP += 0.06f;        
    }

    void FixedUpdate()
    {
        if (onoff == true)
        {
            fillIng.fillAmount = coinHP;
            // 게임 속의 점수가 올라갈 때마다 여기서 올라가도록 장치해야함.
            if (fillIng.fillAmount > 0.047 && fillIng.fillAmount < 0.773)
            {
                Destroy(star);
                star1.SetActive(true);
            }
            if (fillIng.fillAmount > 0.773 && fillIng.fillAmount < 0.961)
            {
                Destroy(star1);
                star2.SetActive(true);
            }
            if (fillIng.fillAmount > 0.961)
            {
                Destroy(star2);
                star3.SetActive(true);
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
