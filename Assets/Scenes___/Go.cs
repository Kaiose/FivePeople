using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go : MonoBehaviour {

    Manager ma;
	// Use this for initialization
	void Start () {
        ma = GameObject.FindObjectOfType<Manager>();
	}
	IEnumerator go()
    {
        ma.go = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scenes___/MainScene___");
    }
	// Update is called once per frame
	void Update () {
		if(ma.go==true)
        {
            StartCoroutine(go());
        }
	}
}
