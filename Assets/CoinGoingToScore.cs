using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGoingToScore : MonoBehaviour {

    Game game_;
    Cube cb;
    public GameObject coin;
    public Transform coinlocation;
    private Transform startlocation;

    

    // Use this for initialization
    void Start () {
        //startlocation = cb.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void update () {
        {
            coin.SetActive(true);
            coin.transform.position = Vector3.MoveTowards(coin.transform.position, coinlocation.position, 30.0f * Time.deltaTime);
            if (coin.transform.position == coinlocation.position) Destroy(coin);
        }
	}
}
