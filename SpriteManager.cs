using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

public class SpriteManager : MonoBehaviour {

    static protected SpriteManager s_SpriteInstance;
    static public SpriteManager SpriteInstance { get { return s_SpriteInstance; } }
    private SpriteRenderer[] spriteRenderer;

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
    // Use this for initialization

    void Awake()
    {
        s_SpriteInstance = this;
    }
    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StageSpriteUpdate(string stage)
    {
        print("StartStageSpriteUpdate");
        spriteRenderer = StageGroup.GetComponentsInChildren<SpriteRenderer>();

        bool StageState = false;

        foreach (SpriteRenderer child in spriteRenderer)
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
