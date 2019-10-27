using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPotions : MonoBehaviour
{

    // Referenced https://www.studica.com/blog/unity-ui-tutorial-scroll-grid for how to create a scroll area
    // that is populated with items/game objects 
    // Referenced https://stackoverflow.com/questions/39099265/horizontal-scrollview-with-images-constant-height-in-unity3d-ui-how
    // for how to make the scroll area just horizontally scroll 
    public int number;
    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToPotionInventory(Image potion)
    {
        // Add the potion to the inventory and assign the clone the name "potion"
        Instantiate(potion, transform).name = "potion";

    }
}
