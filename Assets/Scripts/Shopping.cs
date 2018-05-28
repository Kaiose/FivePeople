using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopping : MonoBehaviour {

    public int Money;
    public Text Warning;
    Manager manager;
    private void Start()
    {
        manager = FindObjectOfType<Manager>();
    }
    private void OnMouseDown()
    {
        if(manager.cur_user.money>=Money)
        {
            Warning.color = Color.green;
            manager.cur_user.money -= Money;
            manager.cur_user.game_money += Money;
            Warning.text = "Cost" + Money + "Now:" + manager.cur_user.money+"$";
           
            manager.saveData();
         
        }
        else
        {
            Warning.color = Color.red;
            Warning.text = "Not Enough Money! " + "Now:" + manager.cur_user.money+"$";
        }
    }
}
