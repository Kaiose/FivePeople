using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour {

    public string GoThisScene;
    // Use this for initialization
    private void OnMouseDown()
    {
        SceneManager.LoadScene(GoThisScene);
    }
}
