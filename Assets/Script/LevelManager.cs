using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class LevelManager : MonoBehaviour
    {
        
        private short CurrentLevel = 1; //Load Data

        // Use this for initialization
        void Awake()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Screen.SetResolution(545, 969, false);
        }
        void Start()
        {
            if (CheckBackUpFile())
            {
                /*왕이센씨 유저 데이터 호출
                * File Open  and Get Level -> Change CurrentLevel
                * 
                */
            }

        }

        // Update is called once per frame
        void Update()
        {
            IncreaseLevel();

        }



        void IncreaseLevel()
        {
           // if (HeartManager.HeartInstance.GetHeartCount() <= 0) return;
            if (Input.GetKeyDown("space"))
            {
                print("Press space");
                HeartManager.HeartInstance.decreaseHeart();
                CurrentLevel += 1; //Save Data;
                StageSpriteUpdate();
            }
        }

        bool CheckBackUpFile()
        {


            return false;
        }

        void StageSpriteUpdate()
        {
            print("Stage");
            string Stage = "Stage";
            string stageNumber = CurrentLevel.ToString();
            Stage += stageNumber;
            SpriteManager.SpriteInstance.StageSpriteUpdate(Stage);
        } 

    }
}