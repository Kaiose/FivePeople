using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManager;
public class GoldTextCopy : MonoBehaviour {

    [SerializeField]
    private Text GoldCount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = GoldCount.text;
	}
}
