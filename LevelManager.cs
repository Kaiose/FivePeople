using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class LevelManager : MonoBehaviour
    {
        
        public short CurrentLevel = 1;

       

        // Use this for initialization
        void Start()
        {
            if (CheckBackUpFile())
            {
                /*
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
            if (Input.GetKeyDown("space"))
            {
                print("space Down");
                CurrentLevel += 1;
                StageSpriteUpdate();
            }
        }

        bool CheckBackUpFile()
        {


            return false;
        }

        void StageSpriteUpdate()
        {
            string Stage = "Stage";
            string stageNumber = CurrentLevel.ToString();
            Stage += stageNumber;
            print(Stage);
            SpriteManager.SpriteInstance.StageSpriteUpdate(Stage);
        }
        

    }
}