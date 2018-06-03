using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    // 블록이 파괴되는 부분에 AddScore함수를 추가해주면, 위에 스코어 창에 점수가 오르는 것을 확인할 수 있다.

    /*
     *  스코어가 오르는 곳에 LowCanvas 속에 있는 Combo들을 활성화 시켜주는 코드를 넣어야 한다. 
    */
    public static ScoreManager instance;
    public GameObject GameclearScene;
    public Hpbar hp;
    public StarOn so;
    public Text coinText;
    public Text coinText2;
    public Text turn;
    public Text scoreText;
    public Text jellyScore;




    // SAVE SCORE AND COIN!!
    private int score_ = 0;
    private int coin = 0;
    private int lessturn = 20;
    private int jelly = 0;
    public GameObject gameover;


    // 이 게임에서는 Score랑 coin이랑 같은 역할을 하는 것 같음.
    // 그러므로 score변수지만 코인이 오르도록 함.

    // 코인 유지!! ( Need to save the coin for whole scene )

    void Awake()
    {
        if (!instance)
            instance = this;
    }

    public void AddScore(int num)
    {
        //load coin
        coin += num;
        coinText.text = " " + coin;
        coinText2.text = " " + coin;
        score_ += num * 20;
        scoreText.text = " " + score_;
        //sace coin
    }

    public void LessTurn()
    {
        lessturn--;
        turn.text = " " + lessturn;
        if (lessturn == 0)
        {
            gameover.SetActive(true);
        }
    }


    public void AddMainScore()
    {
        jelly += 1;
        jellyScore.text = " " + jelly;
        if (jelly >= 12f)
        {
            Time.timeScale = 0.0f;
            GameclearScene.SetActive(true);
            hp.StopThis();
            so.Off();
            jellyScore.text = " " + 12f;
        }
    }
}
