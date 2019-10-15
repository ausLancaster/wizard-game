using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyHighlight : MonoBehaviour
{
    public KeyCode key;

    Outline Outline;

    private void Awake()
    {
        Outline = GetComponent<Outline>();
    }
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key) == true)
        {
            Outline.enabled = true;
            //Debug.Log("key pressed");
        }

        else if (Input.GetKeyUp(key) == true)
        {
            Outline.enabled = false;
        }

    }
}
