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

    public bool ingredientsEnabled = true;
    public GameObject noPotionsPanel;
    public GameObject poweredUpPanel;
    public GameObject explosionIncPanel;
    public GameObject damageIncPanel;

    public ItemAnimation catAnimation;
    public ItemAnimation eggAnimation;
    public bool poweredUp;
    public bool damageIncreased;
    public int queueTracker;
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
        damageIncreased = false;
        queueTracker = 0;
        catAnimation = GameObject.Find("Button 4").GetComponent<ItemAnimation>();
        eggAnimation = GameObject.Find("Button 5").GetComponent<ItemAnimation>();
        eggAnimation.enabled = false;
        catAnimation.enabled = false;
        disableDelay = 0.5f;
    }

    void Update()
    {
        // Pop-up messages 
        displayTime -= Time.deltaTime;
        if (displayTime <= 0)
        {
            noPotionsMessage = false;
            noPotionsPanel.SetActive(false);
            explosionIncPanel.SetActive(false);
            damageIncPanel.SetActive(false);
        }

        if (numPotions == 0)
        {
            poweredUp = false;
            poweredUpPanel.SetActive(false);
            catAnimation.enabled = false;
            eggAnimation.enabled = false;
            queueTracker = 0;
        }

        // Potion with caterpillar/egg added has been thrown
        if (poweredUp && numPotions != 0)
        {
            if (numPotions == queueTracker - 1)
            {
                catAnimation.enabled = true;
                eggAnimation.enabled = true;
                poweredUpPanel.SetActive(false);
                queueTracker = 0;
                poweredUp = false;
                damageIncreased = false;
            }
            else
            {
                // Do not allow caterpillar/egg to be added a second time
                poweredUpPanel.SetActive(true);
                // allow time for animation before disabling
                disableDelay -= Time.deltaTime;
                if (disableDelay <= 0)
                {
                    catAnimation.enabled = false;
                    eggAnimation.enabled = false;
                }
                // keep track of powered up potion in queue
                queueTracker = numPotions;
            }
        }


        // There are potions available to be powered up by caterpillar/egg
        if (!poweredUp && numPotions > 0)
        {
            catAnimation.enabled = true;
            eggAnimation.enabled = true;
            queueTracker = 0;
            poweredUpPanel.SetActive(false);
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
        damageIncreased = true;
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
        SceneManager.LoadScene("GameOver");
 
    }


    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

