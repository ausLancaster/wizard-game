using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    Inventory Inventory;
    public InGameController GC;
    public float time = 1.0f;

    public int leafUsed;
    public int flowerUsed;
    public int eyeUsed;
    public int catUsed;
    public int eggUsed;
    public int eyebrowUsed;


    private void Awake()
    {
        Inventory = GetComponent<Inventory>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set all the number of items used to 0 initially 
        leafUsed = 0;
        flowerUsed = 0;
        eyeUsed = 0;
        catUsed = 0;
        eggUsed = 0;
        eyebrowUsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // If ingredients are enabled, use the items 
        if (GC.ingredientsEnabled)
        {
            // Depending on the key pressed, use that item if the player has more than 0 in their inventory 
            if (Input.GetKeyDown(KeyCode.Alpha1) == true)
            {
                if (Inventory.leafCount > 0)
                {
                    Debug.Log("test");
                    leafUsed = 1;
                }

            }

            if (Input.GetKeyDown(KeyCode.Alpha2) == true)
            {
                if (Inventory.flowerCount > 0)
                {
                    flowerUsed = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) == true)
            {
                if (Inventory.eyeCount > 0)
                {
                    eyeUsed = 1;
                }
            }

            // If the player has yet to power up their potion and actually has a potion in their inventory, apply the
            // respective power up to the next potion that is going to be thrown 
            if (Input.GetKeyDown(KeyCode.Alpha4) == true && !GC.poweredUp && GC.numPotions!=0)
            {
                if (Inventory.caterpillarCount > 0)
                {
                    catUsed = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha5) == true && !GC.poweredUp && GC.numPotions!=0)
            {
                if (Inventory.eggCount > 0)
                {
                    eggUsed = 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha6) == true)
            {
                if (Inventory.eyebrowCount > 0)
                {
                    eyebrowUsed = 1;
                }
            }
        }
        time -= Time.deltaTime;
        // Reset the potion that is being mixed after a second 
        if (time <=0)
        {
            UpdateCount(leafUsed, flowerUsed, eyeUsed, catUsed, eggUsed, eyebrowUsed);
            ResetCount();
            time = 1.0f;
        }

    }

    // Update the count of the items that are in the player's inventory 
    public void UpdateCount(int leaf, int flower, int eye, int cat, int egg, int eyebrow)
    {
        Inventory.leafCount -= leaf;
        Inventory.flowerCount -= flower;
        Inventory.eyeCount -= eye;
        Inventory.caterpillarCount -= cat;
        Inventory.eggCount -= egg;
        Inventory.eyebrowCount -= eyebrow;
    }

    // Reset the count of the items that are being used by the player
    public void ResetCount()
    {
        leafUsed = 0;
        flowerUsed = 0;
        eyeUsed = 0;
        catUsed = 0;
        eggUsed = 0;
        eyebrowUsed = 0;
    }

}


