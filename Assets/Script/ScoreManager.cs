using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    // 블록이 파괴되는 부분에 AddScore함수를 추가해주면, 위에 스코어 창에 점수가 오르는 것을 확인할 수 있다.

    /*
     *  스코어가 오르는 곳에 LowCanvas 속에 있는 Combo들을 활성화 시켜주는 코드를 넣어야 한다. 
    */
    public static ScoreManager instance; 
    public Text scoreText; 
    private int score = 0;


    void Awake()
    {
        if (!instance) 
            instance = this; 
    }

    public void AddScore(int num) 
    {
        score += num; 
        scoreText.text += score; 
    }    
}
