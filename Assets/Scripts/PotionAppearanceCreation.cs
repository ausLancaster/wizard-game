using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionAppearanceCreation : MonoBehaviour
{
    public InGameController GC;
    public HealthManager HealthManager;
	private int sum = 0;
    private int keyPress = 0;
    private float resetTime = 1.0f;
    private InventoryPotions InventoryPotions;
    private Image firePotion;
    private Inventory Inventory;
    private Image previousPotion;
    private bool caterpillarAdded;
    private bool eggAdded;
    private Outline childOutline;
    private ItemsInPotion items;
    private bool special;
    private bool waitForSpecial = false;
    private bool normalItems = true;
    private bool baseMade = false;

    // Different potion types 
    public Image fire;
    public Image poison;
    public Image acid;
    public Image health;
    public Image failed;
    public Image plain;
    // Scroll view list of potions 
    public GameObject potions;
    // Base potion image 
    public Image potionImage;
    // The player game object 
    public GameObject player;
    // Scroll view list of items added to the potions
    public GameObject addedItems;
    public bool reset;

    private void Awake()
    {
        potionImage = GetComponent<Image>();
        InventoryPotions = potions.GetComponent<InventoryPotions>();
        Inventory = player.GetComponent<Inventory>();
        items = addedItems.GetComponent<ItemsInPotion>();
    }

    // Start is called before the first frame update
    void Start()
    {
        reset = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If ingredients are enabled, add them to the potion when the key is pressed 
        if (GC.ingredientsEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && Inventory.leafCount > 0)
            {
                // leaf added
                AddItem(2, items.leaf);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && Inventory.flowerCount > 0)
            {
                // flower added 
                AddItem(3, items.flower);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && Inventory.eyeCount > 0)
            {
                // eyeball added
                AddItem(5, items.eye);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6) && Inventory.eyebrowCount > 0)
            {
                // eyebrows added
                AddItem(13, items.eyebrows);
            }
        }


        // If reset is true, disbale the ingredients and reset everything, the enable the ingredients and set
        // reset to false again 
        if (reset)
        {
            GC.ingredientsEnabled = false;
            resetTime -= Time.deltaTime;
            if (resetTime<0)
            {
                items.ClearItemList();
                potionImage.sprite = plain.sprite;
                sum = 0;
                keyPress = 0;
                resetTime = 1.0f;
                GC.ingredientsEnabled = true;
                reset = false;
            }
        }

        // If the keys have been pressed twice, check their sum and if their sum corresponds with
        // one of the potions that are in the spellbook, make that potion and add it to the potion inventory.
        // Otherwise it is a "failed" potion and do nothing 
        if (keyPress == 2)
        {
            
            if (sum == 5)
            {
                // Leaf and flower
                CreatePotionAndAdd(fire, "fire"); 
            }
            else if (sum == 7)
            {
                // Leaf and eyeball
                CreatePotionAndAdd(poison,"poison");
            }
            else if (sum == 8)
            {
                // Flower and eyeball
                CreatePotionAndAdd(acid,"acid");
            }
            else if (sum == 16)
            {
                // Flower and eyebrows 
                // Add to health inventory
                HealthManager.healthPotionCount++;
            }
            else
            {
                potionImage.sprite = failed.sprite;
            }
            // Reset values
            sum = 0;
            keyPress = 0;
            reset = true;
        }

        // If the caterpillar button is pressed and there are caterpillars in the inventory and the potion has
        // yet to be powered up
        // Referenced https://answers.unity.com/questions/29481/how-to-see-if-transform-has-child.html for seeing if
        // a game object has children
        else if (Input.GetKeyDown(KeyCode.Alpha4) && potions.transform.childCount > 0 && Inventory.caterpillarCount > 0 && !GC.poweredUp && GC.ingredientsEnabled)
        {
            // Caterpillar added
            special = true;
            // Get the outline of the potion in the potion inventory and give it a cool effect 
            childOutline = potions.transform.GetChild(potions.transform.childCount - GC.numPotions).gameObject.GetComponent<Outline>();
            // Referenced https://docs.unity3d.com/ScriptReference/Color-ctor.html for how to use the colour constructor 
            childOutline.effectColor = new Color(0.13f, 1.0f, 0.0f, 1.0f);
            childOutline.effectDistance = new Vector2(5, 2);

            // Indicate the potion has been powered up and tell the player in the UI
            GC.poweredUp = true;
            GC.DamageIncMessage();
        }
        // Do the same for if an egg has been added
        else if (Input.GetKeyDown(KeyCode.Alpha5) && potions.transform.childCount > 0 && Inventory.eggCount > 0 && !GC.poweredUp && GC.ingredientsEnabled)
        {
            // Egg added
            childOutline = potions.transform.GetChild(potions.transform.childCount - GC.numPotions).gameObject.GetComponent<Outline>();
            childOutline.effectColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            childOutline.effectDistance = new Vector2(5, 2);

            GC.poweredUp = true;
            GC.ExplosionIncMessage();

        }
    }

    // Function for creating the image of the potion and adding it to the inventory 
    private void CreatePotionAndAdd(Image potionType, string potionName)
    {
        // Referenced https://forum.unity.com/threads/solved-changing-ui-image-with-script.440347/ for how to
        // change the image of an image 
        potionImage.sprite = potionType.sprite;
        InventoryPotions.AddToPotionInventory(potionType);
        GC.potionQueue.Add(potionName);
        GC.numPotions++;
    }

    // Funtion for adding items to the list of items that have been added to the inventory 
    private void AddItem(int value, Image item)
    {
        items.AddItemToList(item, caterpillarAdded);
        sum += value;
        keyPress++;

    }
}
