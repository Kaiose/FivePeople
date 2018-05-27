using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManager;
public class HeartGenerateTime : MonoBehaviour {

   

    [SerializeField]
    private Text HeartGenerationTime;


    Coroutine CheckCountDown = null;
    void Awake()
    {

    }
	// Use this for initialization
	void Start () {
        StartCoroutine("CountDown");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        //if (CheckCountDown == null)
        //    StartCoroutine("CountDown");

    }

    IEnumerator CountDown()
    {
        int Min = 30;
        float Sec = 0f;
        while (Min != 0 || (int)Sec != 0)
        {

            Sec -= 1*Time.deltaTime;
            if((int)Sec == -1)
            {
                Min -= 1;
                Sec = 59;
            }
            if(Min/10 == 0 && (int)Sec/10 == 0)
                HeartGenerationTime.text = "0" + Min + ":0" + (int)Sec;
            else if(Min/10 != 0 && (int)Sec /10 == 0)
                HeartGenerationTime.text = "" + Min + ":0" + (int)Sec;
            else if (Min/10 == 0 && (int)Sec / 10 != 0)
                HeartGenerationTime.text = "0" + Min + ":" + (int)Sec;
            else
                HeartGenerationTime.text = "" + Min + ":" + (int)Sec;
            yield return null;
        }
        HeartManager.HeartInstance.IncreaseHeart();
        CountDown();
    }

}
