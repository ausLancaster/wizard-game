using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsInPotion : MonoBehaviour
{
    public Image leaf;
    public Image flower;
    public Image eye;
    public Image caterpillar;
    public Image egg;
    public Image eyebrows;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItemToList(Image item, bool caterpillar)
    {
        Instantiate(item, transform);
    }

    public void ClearItemList()
    {
        // Referenced https://answers.unity.com/questions/611850/destroy-all-children-of-object.html for how
        // to desroy al children of a game object
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
