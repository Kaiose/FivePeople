using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour
{

  
    public Texture2D cursorTexture;
    public bool hotSpotIsCenter = false;
    
    // 좌표
    public Vector2 adjustHotSpot = Vector2.zero;
    
    private Vector2 hotSpot;
    public void Start()
    {
        StartCoroutine("MyCursor");
    }
    
    IEnumerator MyCursor()
    {

        
        yield return new WaitForEndOfFrame();

      
        if (hotSpotIsCenter)
        {
            hotSpot.x = cursorTexture.width / 2;
            hotSpot.y = cursorTexture.height / 2;
        }
        else
        {
           
            hotSpot = adjustHotSpot;
        }
     
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
}