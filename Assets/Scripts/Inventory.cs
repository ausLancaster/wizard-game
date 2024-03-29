﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Inistialise the values of the item counts 
    public int leafCount = 0;
    public int flowerCount = 0;
    public int eyeCount = 0;
    public int caterpillarCount = 0;
    public int eggCount = 0;
    public int eyebrowCount = 0;

    // Get the text elements for where the item counts are going to be displayed
    public Text inventoryCountLeaf;
    public Text inventoryCountFlower;
    public Text inventoryCountEye;
    public Text inventoryCountCaterpillar;
    public Text inventoryCountEgg;
    public Text inventoryCountEyebrow;

    public MusicController MC;

    // Start is called before the first frame update
    void Start()
    {
        // Update all the displayed counts at the start of the game so that they all
        // display the initial amounts 
        updateAllCountDisplays();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the counts each frame so that they are up to date 
        updateAllCountDisplays();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Item"))
        {
            // Play the item pickup sound when picking up an item 
            MC.PlayItemPickUp();

            // Check which item it being picked up and increment the count for that item respectively
            if (other.gameObject.name == "Leaf")
            {
                leafCount++;
                Debug.Log("current leaves " + leafCount);
                inventoryCountLeaf.text = leafCount.ToString();
            }

            else if (other.gameObject.name == "Flower")
            {
                flowerCount++;
                Debug.Log("current flowers" + flowerCount);
                inventoryCountFlower.text = flowerCount.ToString();
            }

            else if (other.gameObject.name == "Blob eye")
            {
                eyeCount++;
                Debug.Log("current eyes" + eyeCount);
                inventoryCountEye.text = eyeCount.ToString();
            }

            else if (other.gameObject.name == "Caterpillar")
            {
                caterpillarCount++;
                Debug.Log("current caterpillar" + caterpillarCount);
                inventoryCountCaterpillar.text = caterpillarCount.ToString();
            }

            else if (other.gameObject.name == "Egg")
            {
                eggCount++;
                Debug.Log("current eggs" + eggCount);
                inventoryCountEgg.text = eggCount.ToString();
            }

            else if (other.gameObject.name == "Eyebrows")
            {
                eyebrowCount++;
                Debug.Log("current eyebrows" + eyebrowCount);
                inventoryCountEyebrow.text = eyebrowCount.ToString();
            }
            // Once the item has been picked up, destroy it 
            Destroy(other.gameObject);
        }
    }

    // Function for updating the displayed values of all the inventory items 
    public void updateAllCountDisplays()
    {
        inventoryCountLeaf.text = leafCount.ToString();
        inventoryCountFlower.text = flowerCount.ToString();
        inventoryCountEye.text = eyeCount.ToString();
        inventoryCountCaterpillar.text = caterpillarCount.ToString();
        inventoryCountEgg.text = eggCount.ToString();
        inventoryCountEyebrow.text = eyebrowCount.ToString();
    }
}
