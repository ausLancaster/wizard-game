using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables globalVariables;
    public InputField inputField;
    public string playerName;

    private void Awake()
    {
        
        if (globalVariables == null)
        {
            globalVariables = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (playerName != inputField.text)
        {
            playerName = inputField.text;
        } 
    }
}
