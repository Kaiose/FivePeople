using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundControl : MonoBehaviour {
    public AudioClip temp;
    private bool flag = false;
    [SerializeField]
    private GameObject Audio;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AudioControl()
    {
        flag = !flag;
        if (!flag)
            Audio.SetActive(true);
        else
            Audio.SetActive(false);
    }

    public void Oneshot()
    {
        Audio.GetComponent<AudioSource>().PlayOneShot(temp);
    }
}
