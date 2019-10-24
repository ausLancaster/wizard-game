using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    //public GameObject leaf;
    Inventory Inventory;
    public InGameController GC;

    private void Awake()
    {
        Inventory = GetComponent<Inventory>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GC.ingredientsEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) == true)
            {
                if (Inventory.leafCount > 0)
                {
                    Debug.Log("test");
                    Inventory.leafCount--;
                }

            }

            else if (Input.GetKeyDown(KeyCode.Alpha2) == true)
            {
                if (Inventory.flowerCount > 0)
                {
                    Inventory.flowerCount--;
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3) == true)
            {
                if (Inventory.eyeCount > 0)
                {
                    Inventory.eyeCount--;
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha4) == true && GC.catEnabled)
            {
                if (Inventory.caterpillarCount > 0)
                {
                    Inventory.caterpillarCount--;
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha5) == true && GC.eggEnabled)
            {
                if (Inventory.eggCount > 0)
                {
                    Inventory.eggCount--;
                }
            }

            else if (Input.GetKeyDown(KeyCode.Alpha6) == true)
            {
                if (Inventory.eyebrowCount > 0)
                {
                    Inventory.eyebrowCount--;
                }
            }
        }
    }
}
