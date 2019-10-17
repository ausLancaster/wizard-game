using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameController : MonoBehaviour
{
    public HealthManager healthManager;
    public PlayerController player;
    public UI_Manager UI;
    public Canvas pausedCanvas;
    public Canvas inventoryCanvas;

    void Start()
    {
        GameObject pausedMenu = GameObject.Find("PausedCanvas");
        pausedCanvas = pausedMenu.GetComponent<Canvas>();
        pausedCanvas.enabled = false;

        GameObject inventory = GameObject.Find("UI");
        inventoryCanvas = inventory.GetComponent<Canvas>();
        inventoryCanvas.enabled = true;
    }

    void Update()
    {
        
    }

    public void ToggleInventory()
    {
        if (inventoryCanvas.enabled)
        {
            inventoryCanvas.enabled = false;
        }
        else
        {
            inventoryCanvas.enabled = true;
        }
    }

    public void TogglePauseMenu()
    {
        ToggleInventory();
        // not the optimal way but for the sake of readability
        if (pausedCanvas.enabled)
        {
            pausedCanvas.enabled = false;
            UI.controlsCanvas.enabled = false;
            UI.exitCanvas.enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            pausedCanvas.enabled = true;
            Time.timeScale = 0f;
        }
    }

    public void GameOver()
    {

    }


    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

