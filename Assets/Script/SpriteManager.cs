using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour {

    static protected SpriteManager s_SpriteInstance;
    static public SpriteManager SpriteInstance { get { return s_SpriteInstance; } }
    private SpriteRenderer[] StageSpriteRenderer;
    private SpriteRenderer CurrentSpriteRenderer;
	
    [SerializeField]
    private GameObject StageGroup;
    [SerializeField]
    private Sprite StageClear;
    [SerializeField]
    private Sprite StageOpen;
    [SerializeField]
    private Sprite StageUnOpen;
    [SerializeField]
    private GameObject Indicator;
    [SerializeField]
    private Text HeartCount;
    [SerializeField]
    private Text GoldCount;
    // Use this for initialization

    void Awake()
    {
        s_SpriteInstance = this;

    }
    
    void Start () {
        StageSpriteRenderer = StageGroup.GetComponentsInChildren<SpriteRenderer>();
       
    }
	
    void Enable()
    {
   
    }

	// Update is called once per frame
	void Update () {

    }

    public void HeartCountSpriteUpdate()
    {
        print("HeartCountSpriteUpdate");
        int CurrentHeartCount = HeartManager.HeartInstance.GetHeartCount();

        HeartCount.text = CurrentHeartCount.ToString();
     
 
    }

    public void GoldCountSpriteUpdate()
    {
        print("GoldCountSpriteUpdate");
        int CurrentGoldCount = GoldManager.GoldInstance.GetGoldCount();
        

        GoldCount.text = CurrentGoldCount.ToString();
    }

    public void StageSpriteUpdate(string stage)
    {
        print("StartStageSpriteUpdate");
        bool StageState = false;

        foreach (SpriteRenderer child in StageSpriteRenderer)
        {

            if(child.gameObject.name.CompareTo(stage) == 0 && StageState == false)
            {
                Indicator.transform.position = new Vector3(child.gameObject.transform.position.x, child.gameObject.transform.position.y+1,0);
                child.sprite = StageOpen;
                StageState = true;
            }
            if (StageState == false)
            {
                child.sprite = StageClear;
            }

        }

    }

}
