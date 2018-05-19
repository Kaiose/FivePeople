using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarOn : MonoBehaviour {

    Image fillIng;
    public float timeAmt = 10;
    float time;

    public GameObject star;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;



    void Start()
    {
        fillIng = this.GetComponent<Image>();
        time = timeAmt;
    }

    /*
        시간이 지남에 따라서 hp가 줄어들고, 일정치 줄어들면, Red Bar가 생성된다. 
    */
    void FixedUpdate()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            fillIng.fillAmount = time / timeAmt;
            if (fillIng.fillAmount < 0.962 && fillIng.fillAmount > 0.762)
            {
                Destroy(star);
                star1.SetActive(true);
            }
            if (fillIng.fillAmount < 0.762 && fillIng.fillAmount > 0.048)
            {
                Destroy(star1);
                star2.SetActive(true);
            }
            if (fillIng.fillAmount < 0.048)
            {
                Destroy(star2);
                star3.SetActive(true);
            }


        }

       
    }
}
