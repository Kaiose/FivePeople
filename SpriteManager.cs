using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class SpriteManager : MonoBehaviour {

    static protected SpriteManager s_SpriteInstance;
    static public SpriteManager SpriteInstance { get { return s_SpriteInstance; } }
    private SpriteRenderer[] StageSpriteRenderer;
    private SpriteRenderer[] HeartCountSpriteRenderer;
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
    private GameObject CurrentSprite;
    [SerializeField]
    private Sprite[] HeartCountSpriteGroup;

    // Use this for initialization

    void Awake()
    {
        s_SpriteInstance = this;
    }
    
    void Start () {
        StageSpriteRenderer = StageGroup.GetComponentsInChildren<SpriteRenderer>();
        CurrentSpriteRenderer = CurrentSprite.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HeartCountSpriteUpdate()
    {
        print("HeartCountSpriteUpdate");
        int CurrentHeartCount = HeartManager.HeartInstance.GetHeartCount();
      

        CurrentSpriteRenderer.sprite = HeartCountSpriteGroup[CurrentHeartCount];
 
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
