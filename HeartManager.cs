﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
public class HeartManager : MonoBehaviour {

    private int CurrentHeart = 5;
    static protected HeartManager s_HeartInstance;
    static public HeartManager HeartInstance { get { return s_HeartInstance; } }


    // Use this for initialization

    void Awake()
    {
        s_HeartInstance = this;
    }
    void Start () {
  
        //if (CheckBackUpFile())
        //{
        //    /*
        // 왕이센씨 유저 데이터 호출
        //    * File Open  and Get Level -> Change CurrentLevel
        //    * 
        //    */
        //}
        SpriteManager.SpriteInstance.HeartCountSpriteUpdate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseHeart()
    {
        print("IncreaseHeart");
        if (CurrentHeart >= 5) return;
        CurrentHeart += 1;
        SpriteManager.SpriteInstance.HeartCountSpriteUpdate();
        return;
    }
    public void decreaseHeart()
    {

        print("decreaseHeart");
        CurrentHeart -= 1;
        if (CurrentHeart <= 0)
            CurrentHeart = 0;
      
        SpriteManager.SpriteInstance.HeartCountSpriteUpdate();
        return;
    }

    public int GetHeartCount()
    {
        return CurrentHeart;
    }
}
