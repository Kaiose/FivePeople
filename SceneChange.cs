using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    // Use this for initialization

    [SerializeField]
    private string SceneName;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CallScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
