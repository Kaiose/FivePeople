using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
public class GoldManager : MonoBehaviour {


    private int CurrentGold = 200; //LoadData
    static protected GoldManager s_GoldInstance;
    static public GoldManager GoldInstance { get { return s_GoldInstance; } }



    // Use this for initialization
    void Awake()
    {
        s_GoldInstance = this;
    }
    void Start()
    {
        SpriteManager.SpriteInstance.GoldCountSpriteUpdate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetGoldCount()
    {

        return CurrentGold;
    }

    public void IncreaseGold(int IncreasingGold)
    {
        CurrentGold += IncreasingGold; // SaveData
        SpriteManager.SpriteInstance.GoldCountSpriteUpdate();
    }

    public void DecreaseGold(int decreasingGold)
    {

        if (CurrentGold - decreasingGold < 0)
            return;
        CurrentGold -= decreasingGold; //LoadData
        SpriteManager.SpriteInstance.GoldCountSpriteUpdate();
    }
}
