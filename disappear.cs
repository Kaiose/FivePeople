using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour {

    [SerializeField]
    private float time;
    public GameObject dissapear;


	// Use this for initialization
	void Start () {
        time = 5.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        time -= Time.deltaTime;

        dissapear.transform.Translate(new Vector3(4.0f, 2.0f) * Time.deltaTime);
        if (time < 1.0f) dissapear.transform.Translate(new Vector3(500.0f, 20.0f) * Time.deltaTime);

        if (time < -10.0f) Destroy(dissapear);
    }
}
