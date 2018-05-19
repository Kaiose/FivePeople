using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour {

    Image fillIng;
    public float timeAmt = 10;
    float time;
    bool OnOff;

    public GameObject lowhealth;

    void Start()
    {
        OnOff = true;
        fillIng = this.GetComponent<Image>();
        time = timeAmt;
    }

    /*
        시간이 지남에 따라서 hp가 줄어들고, 일정치 줄어들면, Red Bar가 생성된다. 
    */
    void FixedUpdate()
    {
        if (OnOff == true)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                fillIng.fillAmount = time / timeAmt;
                if (fillIng.fillAmount < 0.3)
                {
                    lowhealth.SetActive(true);
                    Destroy(this.gameObject);
                }
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
