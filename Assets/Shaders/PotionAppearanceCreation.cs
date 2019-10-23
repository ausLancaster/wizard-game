using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionAppearanceCreation : MonoBehaviour
{
    public InGameController GC;
	private int sum = 0;
    private int keyPress = 0;
    private float resetTime = 2.0f;
    private InventoryPotions InventoryPotions;
    private Image firePotion;
    private Inventory Inventory;
    private Image previousPotion;
    private bool caterpillarAdded;
    private bool eggAdded;
    private Outline potionOutline;
    private ItemsInPotion items;
    private bool special;
    private bool waitForSpecial = false;
    private bool normalItems = true;
    private bool baseMade = false;
    private Image specialPotion;

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
        
    }

    // Update is called once per frame
    void Update()
    {   if (GC.ingredientsEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) /*&& Inventory.leafCount > 0*/)
            {
                // leaf added
                //sum += 2;
                //keyPress++;
                AddItem(2, items.leaf);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) /*&& Inventory.flowerCount > 0*/)
            {
                // flower added 
                //sum += 3;
                //keyPress++;
                AddItem(3, items.flower);
                //items.AddItemToList(items.flower, caterpillarAdded);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) /*&& Inventory.eyeCount > 0*/)
            {
                // eyeball added
                //sum += 5;
                //keyPress++;
                AddItem(5, items.eye);
                //items.AddItemToList(items.eye, caterpillarAdded);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                // caterpillar added
                AddItem(7, items.caterpillar);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                // egg added 
                AddItem(11, items.egg);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) == true)
        {
            // eyebrows added
            //sum += 13;
            //keyPress++;
            AddItem(17, items.eyebrows);
            //items.AddItemToList(items.eyebrows, caterpillarAdded);
        }

        if (keyPress==0 && sum==0)
        {
            resetTime -= Time.deltaTime;
            if (resetTime<0)
            {
                potionImage.sprite = plain.sprite;
                potionImage.GetComponent<Outline>().effectColor = plain.GetComponent<Outline>().effectColor;
                potionImage.GetComponent<Outline>().effectDistance = plain.GetComponent<Outline>().effectDistance;
                sum = 0;
                keyPress = 0;
                resetTime = 2.0f;
                GC.ingredientsEnabled = true;
            }
        }

        if (keyPress == 2)
        {
            GC.ingredientsEnabled = false;
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
            else if (sum == 10)
            {
                //potionOutline = fire.GetComponent<Outline>();
                //potionOutline.effectColor = new Color(0.13f, 1.0f, 0.0f, 1.0f);
                //potionOutline.effectDistance = new Vector2(5, 2);
                CreatePotionAndAdd(SpecialPotion(fire, "caterpillar"), "Cfire");
            }
            else if (sum == 12)
            {
                //potionOutline = poison.GetComponent<Outline>();
                //potionOutline.effectColor = new Color(0.13f, 1.0f, 0.0f, 1.0f);
                //potionOutline.effectDistance = new Vector2(5, 2);
                CreatePotionAndAdd(SpecialPotion(poison, "caterpillar"), "Cpoision");
            }
            else if (sum == 14)
            {
                CreatePotionAndAdd(SpecialPotion(fire, "egg"), "Efire");
            }
            else if (sum == 16)
            {
                CreatePotionAndAdd(SpecialPotion(poison, "egg"), "Epoison");
            }
            else if (sum == 20)
            {
                // eyebrows (13) and flower (3)
                //InventoryPotions.AddToPotionInventory(health);
                CreatePotionAndAdd(health,"health");
            }
            else
            {
                potionImage.sprite = failed.sprite;
            }
            sum = 0;
            keyPress = 0;
        }
    }

    private void CreatePotionAndAdd(Image potionType, string potionName)
    {
        potionImage.sprite = potionType.sprite;
        potionImage.GetComponent<Outline>().effectColor = potionType.GetComponent<Outline>().effectColor;
        potionImage.GetComponent<Outline>().effectDistance = potionType.GetComponent<Outline>().effectDistance;
        InventoryPotions.AddToPotionInventory(potionType);
        //waitForSpecial = true;
        //baseMade = true;
        //normalItems = false;
        GC.potionQueue.Add(potionName);
        GC.numPotions++;
    }

    private void AddItem(int value, Image item)
    {
        sum += value;
        keyPress++;
        items.AddItemToList(item, caterpillarAdded);
        //normalItems = true;

    }

    private Image SpecialPotion (Image potion, string type)
    {
        if (type == "caterpillar")
        {
            specialPotion = Instantiate(potion);
            specialPotion.GetComponent<Outline>().effectColor = new Color(0.13f, 1.0f, 0.0f, 1.0f);
            specialPotion.GetComponent<Outline>().effectDistance = new Vector2(5, 2);
            return specialPotion;
        }

        else if (type == "egg")
        {
            specialPotion = Instantiate(potion);
            specialPotion.GetComponent<Outline>().effectColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            specialPotion.GetComponent<Outline>().effectDistance = new Vector2(5, 2);
            return specialPotion;
        }

        // Incase something went wrong- return the normal version of whatever potion was passed in 
        else
        {
            return potion;
        }
    }
}
