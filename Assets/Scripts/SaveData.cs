using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour {

    Manager manager;
    private void Start()
    {
        manager = FindObjectOfType<Manager>();
    }
    bool saveData()
    {
        try
        { 
            string contents = JsonUtility.ToJson(manager.cur_user, true);
            File.WriteAllText(manager.cur_path, contents);
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            return false;
        }
        return true;
    }
}
