using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour
{
    public Text dispName;
    // Start is called before the first frame update
    void Awake()
    {
        dispName = GetComponent<Text>();
        dispName.text = "The Great and Powerful\n" + GlobalVariables.globalVariables.playerName;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
