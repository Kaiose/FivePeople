using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonOnOff : MonoBehaviour {
    public bool ButtonOn;
    private SpriteRenderer spriteRenderer;

	private Image CurrentImage;
    [SerializeField]
    private Sprite SpriteOn;
    [SerializeField]
    private Sprite SpriteOff;

	// Use this for initialization
	void Start()
    {
		CurrentImage = this.GetComponent<Image>();
		
	
    }

    // Update is called once per frame
    void Update()
    {
		
		if (ButtonOn)
		{
			CurrentImage.sprite = SpriteOff;
			
		}
		else
		{
			CurrentImage.sprite = SpriteOn;

		}
	}

    private void OnMouseUp()
    {

    }

    private void OnMouseDown()
    {
        
    }

	public void ChangeButton()
	{
		if (ButtonOn) ButtonOn = false;
		else ButtonOn = true;
	}
	
}
