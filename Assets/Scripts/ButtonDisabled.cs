using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisabled : MonoBehaviour
{
    // Referenced https://answers.unity.com/questions/346719/is-it-possible-to-disable-a-key.html for how
    // to "disable" a button 
    public Text count;

    public bool disabled = false;
    private Image shade;

    // Start is called before the first frame update
    void Start()
    {
        // Get the image for shading out the button 
        shade = gameObject.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        // If there are 0 items, shade out the button 
        if (count.text == "0")
        {
            disabled = true;
            shade.enabled = true;
        }

        // Otherwise do not shade out the button 
        else
        {
            disabled = false;
            shade.enabled = false;
        }
    }
}
