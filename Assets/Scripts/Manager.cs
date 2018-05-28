using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour {

    // Use this for initialization
    static Manager instance;
    
    public UserClass cur_user;
    [HideInInspector]
    public string cur_path;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            cur_user = new UserClass();
            name = "fist instance";
        }
        else if (this != instance)
        { 
            Destroy(gameObject);
        }
    }
    public bool saveData()
    {
        try
        {
            string contents = JsonUtility.ToJson(cur_user, true);
            File.WriteAllText(cur_path, contents);
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            return false;
        }
        return true;
    }
}
