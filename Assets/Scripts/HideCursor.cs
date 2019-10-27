using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    // Referenced https://forum.unity.com/threads/how-to-remove-mouse-cursor-when-i-click-play.37830/ for
    // how to hide the cursor when playing the game 
    // Start is called before the first frame update
    void Start()
    {
        // Make the cursor invisible at the start
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When this function is called, toggle the status of the cursor's visibility
    public void ToggleCursor()
    { 
        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
