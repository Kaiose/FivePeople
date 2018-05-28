using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserClass
{
    public string name;
    public string password;
    public int money;
    public int game_money;
    public int level;
    public int socre;
    public string time;
    public UserClass()
    {
        name = "";
        password = "";
        money = 5000;
        game_money = 0;
        level = 0;
        socre = 0;
        
    }
    public UserClass(string id,string pw)
    {
        name = id;
        password = pw;
        money = 5000;
        game_money = 0;
        level = 0;
        socre = 0;
    
    }
   	
}
