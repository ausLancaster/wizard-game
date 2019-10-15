using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //public GameObject item;
    public int leafCount = 0;
    public int flowerCount = 0;
    public int eyeCount = 0;
    public int caterpillarCount = 0;
    public int eggCount = 0;
    public int eyebrowCount = 0;

    public Text inventoryCountLeaf;
    public Text inventoryCountFlower;
    public Text inventoryCountEye;
    public Text inventoryCountCaterpillar;
    public Text inventoryCountEgg;
    public Text inventoryCountEyebrow;

    // Start is called before the first frame update
    void Start()
    {
        updateAllCountDisplays();
        
    }

    // Update is called once per frame
    void Update()
    {
        updateAllCountDisplays();
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

            Destroy(other.gameObject);
        }
    }

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
