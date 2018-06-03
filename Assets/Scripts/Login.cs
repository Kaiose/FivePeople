using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections;

public class Login : MonoBehaviour
{

    public Text Id;
    public InputField PassWord;
    public Text warning;
    public string TargetScene;
    Manager manager; 
    string path;
    void Start()
    {
        warning.text = "";
        manager = FindObjectOfType<Manager>();
    }
    bool SaveUser(string id, string pw)
    {
        try
        {
            path = Application.persistentDataPath + "/" + id + ".json";
            UserClass new_user = new UserClass(id, pw);
            new_user.time= System.DateTime.Now.ToString(); 
            string contents = JsonUtility.ToJson(new_user, true);
            File.WriteAllText(path, contents);
            manager.cur_user = new_user;
            manager.cur_path = path;
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
            return false;
        }

        return true;
    }
    bool LoadUser(string id, string pw)
    {
        if (id == "" || pw == "")
        {
            warning.text = "Can't Be Empty!";
            return false;
        }
        path = Application.persistentDataPath + "/" + id + ".json";
        if (File.Exists(path))
        {
            string contents = File.ReadAllText(path);
            if (contents != "")
            {
                UserClass user = JsonUtility.FromJson<UserClass>(contents);
                if (user.name == id)
                {
                    if (user.password == pw)
                    {
                        manager.cur_path = path;
                        manager.cur_user = user;
                        return true;
                    }
                    else
                    {
                        warning.text = "Incorrect PassWord";
                        return false;
                    }
                }
            }
        }
        if(SaveUser(id, pw))
            return true;
        return false;
    }
   
    private void OnMouseDown()
    {
        if (LoadUser(Id.text, PassWord.text) == true)
        {
            
                warning.text = "";
                GameObject.Find("Canvas").SetActive(false);
                GameObject.Find("login").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("background").GetComponent<Animation>().Play();
                
                manager.state = true;

        }
    }
}
