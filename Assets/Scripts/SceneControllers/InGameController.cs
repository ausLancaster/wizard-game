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
    bool noPotionsMessage = false;

    public bool ingredientsEnabled=true;
    public GameObject noPotionsPanel;
    public GameObject poweredUpPanel;
    public GameObject explosionIncPanel;
    public GameObject damageIncPanel;

    public bool poweredUp;
    public int queueTracker;
    public ItemAnimation catAnimation;
    public ItemAnimation eggAnimation;
    public float disableDelay;


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
        poweredUpPanel.SetActive(false);
        explosionIncPanel.SetActive(false);
        damageIncPanel.SetActive(false);

        poweredUp = false;
        queueTracker = 0;
        catAnimation = GameObject.Find("Button 4").GetComponent<ItemAnimation>();
        eggAnimation = GameObject.Find("Button 5").GetComponent<ItemAnimation>();
        eggAnimation.enabled = false;
        catAnimation.enabled = false;
        disableDelay = 0.5f;
    }

    void Update()
    {
        displayTime -= Time.deltaTime;
        if (displayTime <=0)
        {
            noPotionsMessage= false;
            noPotionsPanel.SetActive(false);
            explosionIncPanel.SetActive(false);
            damageIncPanel.SetActive(false);
        }


        // Potion with caterpillar/egg has been thrown
        if (poweredUp && potionQueue.Count == queueTracker - 1)
        {
            poweredUp = false;
            queueTracker = 0;
            catAnimation.enabled = true;
            eggAnimation.enabled = true;
            poweredUpPanel.SetActive(false);
        }


        if (numPotions==0)
        {
            catAnimation.enabled = false;
            eggAnimation.enabled = false;
        }

        // Only allow either caterpillar/egg to be added once
        if (poweredUp)
        {
            disableDelay -= Time.deltaTime;
            if (disableDelay <= 0)
            {
                catAnimation.enabled = false;
                eggAnimation.enabled = false;
            }

            queueTracker = potionQueue.Count;
            if (potionQueue.Count != 0)
            {
                poweredUpPanel.SetActive(true);
            }
        }
        if (!poweredUp && numPotions>0) //If there are potions for either caterpillar/egg to be added
        {
            catAnimation.enabled = true;
            eggAnimation.enabled = true;
            disableDelay = 0.5f;
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

    public void ExplosionIncMessage() 
    {
        explosionIncPanel.SetActive(true);
        displayTime = 2;
    }
    public void DamageIncMessage()
    {
        damageIncPanel.SetActive(true);
        displayTime = 2;
    }

    public void NoPotionMessage()
    {
        noPotionsMessage = true;
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

