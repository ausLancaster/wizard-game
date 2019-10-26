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
    // Item sprites 
    //public Sprite leaf;
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
    {   if (GC.ingredientsEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && Inventory.leafCount > 0)
            {
                // leaf added
                //sum += 2;
                //keyPress++;
                AddItem(2, items.leaf);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && Inventory.flowerCount > 0)
            {
                // flower added 
                //sum += 3;
                //keyPress++;
                AddItem(3, items.flower);
                //items.AddItemToList(items.flower, caterpillarAdded);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && Inventory.eyeCount > 0)
            {
                // eyeball added
                //sum += 5;
                //keyPress++;
                AddItem(5, items.eye);
                //items.AddItemToList(items.eye, caterpillarAdded);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6) && Inventory.eyebrowCount > 0)
            {
                // eyebrows added
                //sum += 13;
                //keyPress++;
                AddItem(13, items.eyebrows);
                //items.AddItemToList(items.eyebrows, caterpillarAdded);
            }
        }


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

        if (keyPress == 2)
        {
            
            if (sum == 5)
            {
                //potionImage.sprite = fire;
                CreatePotionAndAdd(fire, "fire");                //InventoryPotions.AddToPotionInventory(fire);
            }
            else if (sum == 7)
            {
                //Debug.Log("test");
                //InventoryPotions.AddToPotionInventory(poison);
                CreatePotionAndAdd(poison,"poison");
            }
            else if (sum == 8)
            {
                //InventoryPotions.AddToPotionInventory(acid);
                CreatePotionAndAdd(acid,"acid");
            }
            else if (sum == 16)
            {
                // eyebrows (13) and flower (3)
                //InventoryPotions.AddToPotionInventory(health);
                // Add to health inventory
                HealthManager.healthPotionCount++;
            }
            else
            {
                potionImage.sprite = failed.sprite;
            }
            sum = 0;
            keyPress = 0;
            reset = true;
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4) && potions.transform.childCount > 0 && Inventory.caterpillarCount > 0 && !GC.poweredUp && GC.ingredientsEnabled)
        {
            Debug.Log("why");
            special = true;
            // https://stackoverflow.com/questions/26622675/get-bottom-most-child
            childOutline = potions.transform.GetChild(potions.transform.childCount - GC.numPotions).gameObject.GetComponent<Outline>();
            childOutline.effectColor = new Color(0.13f, 1.0f, 0.0f, 1.0f);
            childOutline.effectDistance = new Vector2(5, 2);

            //potionImage = potions.transform.GetChild(potions.transform.childCount - 1).gameObject.GetComponent<Image>();
            //items.AddItemToList(items.caterpillar, caterpillarAdded);
            GC.poweredUp = true;
            GC.DamageIncMessage();
            //sum = 0;
            //keyPress = 0;
            //waitForSpecial = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && potions.transform.childCount > 0 && Inventory.eggCount > 0 && !GC.poweredUp && GC.ingredientsEnabled)
        {
            // egg added
            childOutline = potions.transform.GetChild(potions.transform.childCount - GC.numPotions).gameObject.GetComponent<Outline>();
            childOutline.effectColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            childOutline.effectDistance = new Vector2(5, 2);

            //potionImage = potions.transform.GetChild(potions.transform.childCount - 1).gameObject.GetComponent<Image>();
            //items.AddItemToList(items.egg, caterpillarAdded);
            GC.poweredUp = true;
            GC.ExplosionIncMessage();
            //sum = 0;
            //keyPress = 0;

        }
    }

    private void CreatePotionAndAdd(Image potionType, string potionName)
    {
        potionImage.sprite = potionType.sprite;
        InventoryPotions.AddToPotionInventory(potionType);
        //waitForSpecial = true;
        //baseMade = true;
        //normalItems = false;
        GC.potionQueue.Add(potionName);
        GC.numPotions++;
    }

    private void AddItem(int value, Image item)
    {
        items.AddItemToList(item, caterpillarAdded);
        sum += value;
        keyPress++;
        //normalItems = true;

    }
}
