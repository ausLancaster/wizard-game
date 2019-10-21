using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public InGameController inGameController;
    public Canvas controlsCanvas;
    public Canvas exitCanvas;

    // Use this for initialization
    void Start()
    {
        GameObject controlsMenu = GameObject.Find("ControlsCanvas");
        controlsCanvas = controlsMenu.GetComponent<Canvas>();
        controlsCanvas.enabled = false;
        GameObject exitPanel = GameObject.Find("ExitCanvas");
        exitCanvas = exitPanel.GetComponent<Canvas>();
        exitCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inGameController.TogglePauseMenu();
        }
    }

    public void ToggleControlsMenu()
    {
        if (controlsCanvas.enabled)
        {
            controlsCanvas.enabled = false;
        }
        else
        {
            controlsCanvas.enabled = true;
        }
    }

    public void ToggleExitPanel()
    {
        if (exitCanvas.enabled)
        {
            exitCanvas.enabled = false;
        }
        else
        {
            exitCanvas.enabled = true;
        }
    }

    public void ExitCurrentGame()
    {
        inGameController.ExitGame();
    }

}

   