using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionAppearanceCreation : MonoBehaviour
{
	private int sum = 0;
    private int keyPress = 0;
    public Image potionImage;
    private float resetTime = 1.0f;
    public GameObject inventory;
    private InventoryPotions InventoryPotions;
    private Image firePotion;

    public Sprite fire;
    public Sprite poison;
    public Sprite acid;
    public Sprite health;
    public Sprite failed;
    public Sprite plain;

    private void Awake()
    {
        potionImage = GetComponent<Image>();
        InventoryPotions = inventory.GetComponent<InventoryPotions>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) == true)
		{
            // leaf added
            sum += 2;
            keyPress++;
		}
        else if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            // flower added 
            sum += 3;
            keyPress++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) == true)
        {
            // eyeball added
            sum += 5;
            keyPress++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) == true)
        {
            // caterpillar added
            sum += 7;
            keyPress++;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) == true)
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
        //Debug.Log("sum is " + sum);

        if (keyPress == 2)
        {
            switch (sum)
            {
                case 5:
                    //potionImage.sprite = fire;
                    CreatePotionAndAdd(fire);
                    break;
                case 7:
                    Debug.Log("test");
                    potionImage.sprite = poison;
                    break;
                case 8:
                    potionImage.sprite = acid;
                    break;
                case 18:
                    potionImage.sprite = health;
                    break;
                default:
                    potionImage.sprite = failed;
                    break;
            }

            // Reset sum and flag for next potion creation 
            sum = 0;
            keyPress = 0;
        }
    }

    private void CreatePotionAndAdd(Sprite potionType)
    {
        potionImage.sprite = potionType;
        InventoryPotions.AddToPotionInventory(potionImage);
    }
}
