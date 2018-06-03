using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class open : MonoBehaviour {

    Manager ma;
    // Use this for initialization
    IEnumerator open1()
    {
        ma.state = false;
        yield return new WaitForSeconds(2);
        GameObject.Find("inside").GetComponent<Animation>().Play();
        ma.go = true;
        GameObject.Find("inside").SetActive(false);
       
    }
    void Start()
    {
        ma = GameObject.FindObjectOfType<Manager>();
    }
    void Update()
    {
        if (ma.state == true)
        StartCoroutine(open1());
    }
}
