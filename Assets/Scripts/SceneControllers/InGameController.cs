using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameController : MonoBehaviour
{
    public HealthManager healthManager;
    public PlayerController player;
    public UI_Manager UI;
    public Canvas pausedCanvas;
    public Canvas inventoryCanvas;
    public int numPotions;
    public List<string> potionQueue = new List<string>();

    float displayTime = 2;
    bool displayMessage = false;

    public bool ingredientsEnabled=true;
    public GameObject noPotionsPanel;


    void Start()
    {
        /*GameObject pausedMenu = GameObject.Find("PausedCanvas");
        pausedCanvas = pausedMenu.GetComponent<Canvas>();*/
        pausedCanvas.enabled = false;

        GameObject inventory = GameObject.Find("UI");
        inventoryCanvas = inventory.GetComponent<Canvas>();
        inventoryCanvas.enabled = true;
        numPotions = 0;
        ingredientsEnabled = true;

        noPotionsPanel.SetActive(false);
    }

    void Update()
    {
        displayTime -= Time.deltaTime;
        if (displayTime <=0)
        {
            displayMessage = false;
            noPotionsPanel.SetActive(false);
        }
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

 

    public void NoPotionMessage()
    {
        displayMessage = true;
        noPotionsPanel.SetActive(true);
        displayTime = 2;
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

