using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;


public class EventManager : MonoBehaviour {
    static protected EventManager s_EventInstance;
    static public EventManager EventInstance { get { return s_EventInstance; } }

    [SerializeField]
    private Renderer FadeSceanRenderer;
    void Awake()
    {
        s_EventInstance = this;
    }
    void Start()
    {
        FadeSceanRenderer.material.color = new Vector4(1, 1, 1, 0);
    }


    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator FadeOut()
    {
        for (float i = 0f; i <= 1; i += 0.1f)
        {
          FadeSceanRenderer.material.color = new Vector4(1, 1, 1, i);
            yield return 0;
        }
    }
    IEnumerator FadeIn()
    {
        for (float i = 1f; i >= 0; i -= 0.1f)
        {
            FadeSceanRenderer.material.color = new Vector4(1, 1, 1, i);
            yield return 0;
        }
    }


    public void test()
    {
        print("call test");
    }

    public void CallFadeOut()
    {
        print("Execute CallFadeOut");
        StartCoroutine("FadeOut");
    }

    public void CallFadeIn()
    {
        print("Execute CallFadeOut");
        StartCoroutine("FadeIn");
    }
}
