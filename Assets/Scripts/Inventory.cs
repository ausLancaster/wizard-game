using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject item;
    public int leafCount = 0;

    public Text inventoryCount;

    // Start is called before the first frame update
    void Start()
    {
        inventoryCount.text = leafCount.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        inventoryCount.text = leafCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");

        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("item found");
            if (other.gameObject.name == "Leaf")
            {
                leafCount++;
                Debug.Log("current leaves " + leafCount);
                inventoryCount.text = leafCount.ToString();
            }

            Destroy(other.gameObject);
        }
    }
}
