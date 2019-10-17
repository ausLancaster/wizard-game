using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public InGameController inGameController;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inGameController.TogglePauseMenu();
        }
    }

}

   