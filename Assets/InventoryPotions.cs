﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPotions : MonoBehaviour
{

    // https://www.studica.com/blog/unity-ui-tutorial-scroll-grid
    public int number;
    public GameObject image;
    //public PotionAppearanceCreation potionAppearanceCreation;

    private void Awake()
    {
        //potionAppearanceCreation = GetComponent<PotionAppearanceCreation>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {

        }
        
    }

    public void AddToPotionInventory(Image potion)
    {
            Instantiate(potion, transform);
    }
}
