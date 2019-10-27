using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionConsumption : MonoBehaviour
{
    public InGameController GC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // When the button for throwing the potions is thrown, remove the potion from the
        // inventory since it has been used 
        if (Input.GetKeyDown(KeyCode.E) ==  true)
        {
            // Remove potions from the inventory as long as there are actually potions in the inventory
            if (gameObject.transform.childCount > 0)
            {
                // Referenced https://answers.unity.com/questions/467900/first-of-a-gameobject.html for how to find the
                // first child game object of a parent game object
                Destroy(gameObject.transform.GetChild(0).gameObject);
                GC.numPotions -= 1;
            }
        }
        
    }
}
