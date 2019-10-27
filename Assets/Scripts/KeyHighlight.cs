using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHighlight : MonoBehaviour
{
    public KeyCode key;
    public Image disableShade;

    Outline Outline;
    ButtonDisabled disabled;

    private void Awake()
    {
        // Get the outline component of the button as well as the image for when the button
        // is disabled 
        Outline = GetComponent<Outline>();
        disabled = disableShade.GetComponent<ButtonDisabled>();
    }
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        // If the button is not disabled 
        if (disabled.disabled == false)
        {
            // Show the outline around the button when the key is being pressed 
            if (Input.GetKeyDown(key) == true)
            {
                Outline.enabled = true;
                //Debug.Log("key pressed");
            }

            // Otherwise do not show the outline
            else if (Input.GetKeyUp(key) == true)
            {
                Outline.enabled = false;
            }
        }



    }
}
