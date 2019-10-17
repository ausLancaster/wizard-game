using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionConsumption : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) ==  true)
        {
            if (gameObject.transform.childCount > 0)
            {
                //Destroy(GameObject.Find("Content").transform.GetChild(0).gameObject);
                // https://answers.unity.com/questions/467900/first-of-a-gameobject.html
                Destroy(gameObject.transform.GetChild(0).gameObject);
            }
        }
        
    }
}
