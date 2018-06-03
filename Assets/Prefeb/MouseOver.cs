using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour {

    public GameObject potion;

	public void MouseOn()
    {
        potion.transform.Rotate(0, Time.deltaTime * 10, 0);
    }

    public void MouseOff()
    {
        potion.transform.Rotate(0, 0, 0);
    }
}
