using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToHome : MonoBehaviour {
    /*
        이 코드는 아래 "Home"이라고 되어 있는 Scene으로 이동시킨다.
        지금은 '포기하기'버튼을 누르면 이동되도록 만들었다.
    */


    public string SceneName;

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("MainScene___");
    }

    public void ReStart()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
