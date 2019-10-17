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
        //if (caterpillar == true)
        //{
        //    if (gameObject.transform.childCount > 3)
        //    {
        //        foreach (Transform child in transform)
        //        {
        //            Destroy(child.gameObject);
        //        }
        //    }
        //}

        //else if (caterpillar == false)      
        //{
        //    if (gameObject.transform.childCount > 2)
        //    {
        //        foreach (Transform child in transform)
        //        {
        //            Destroy(child.gameObject);
        //        }
        //    }
        //} 
    }

    public void AddItemToList(Image item, bool caterpillar)
    {
        Instantiate(item, transform);
        //Debug.Log("why");
    }

    public void ClearItemList()
    {
        // https://answers.unity.com/questions/611850/destroy-all-children-of-object.html
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
