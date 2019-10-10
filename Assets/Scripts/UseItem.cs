using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    //public GameObject leaf;
    Inventory Inventory;

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
        if (Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            if (Inventory.leafCount > 0)
            {
                Debug.Log("test");
                Inventory.leafCount--;
            }
            

        }
        
    }
}
