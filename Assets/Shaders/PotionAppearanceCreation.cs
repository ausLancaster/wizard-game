using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionAppearanceCreation : MonoBehaviour
{
	private int sum = 0;
    private int keyPress = 0;
    private float resetTime = 1.0f;
    private InventoryPotions InventoryPotions;
    private Image firePotion;
    private Inventory Inventory;
    private Image previousPotion;

    public Image fire;
    public Image poison;
    public Image acid;
    public Image health;
    public Image failed;
    public Image plain;
    public GameObject potions;
    public Image potionImage;
    public GameObject player;

    private void Awake()
    {
        potionImage = GetComponent<Image>();
        InventoryPotions = potions.GetComponent<InventoryPotions>();
        Inventory = player.GetComponent<Inventory>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) /*&& Inventory.leafCount > 0*/)
		{
            // leaf added
            sum += 2;
            keyPress++;
		}
        else if (Input.GetKeyDown(KeyCode.Alpha2) /*&& Inventory.flowerCount > 0*/)
        {
            // flower added 
            sum += 3;
            keyPress++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) /*&& Inventory.eyeCount > 0*/)
        {
            // eyeball added
            sum += 5;
            keyPress++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) /*&& Inventory.caterpillarCount > 0*/)
        {
            // caterpillar added
            sum += 7;
            keyPress++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) /*&& Inventory.eggCount > 0*/)
        {
            // egg added
            sum += 11;
            keyPress++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) == true)
        {
            // eyebrows added
            sum += 13;
            keyPress++;
        }


        if (keyPress == 2)
        {
            if (sum == 5)
            {
                //potionImage.sprite = fire;
                CreatePotionAndAdd(fire);
                //InventoryPotions.AddToPotionInventory(fire);
            }
            else if (sum == 7)
            {
                //Debug.Log("test");
                //InventoryPotions.AddToPotionInventory(poison);
                CreatePotionAndAdd(poison);
            }
            else if (sum == 8)
            {
                //InventoryPotions.AddToPotionInventory(acid);
                CreatePotionAndAdd(acid);
            }
            else if (sum == 16)
            {
                // eyebrows (13) and flower (3)
                //InventoryPotions.AddToPotionInventory(health);
                CreatePotionAndAdd(health);
            }
            else
            {
                potionImage.sprite = failed.sprite;
            }

            // Reset sum and flag for next potion creation 
            sum = 0;
            keyPress = 0;
        }


    }

    private void CreatePotionAndAdd(Image potionType)
    {
            potionImage.sprite = potionType.sprite;
            InventoryPotions.AddToPotionInventory(potionType);
    }
}
