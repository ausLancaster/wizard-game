using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPotion : MonoBehaviour
{
    [SerializeField]
    Transform potionPrefab;
    [SerializeField]
    Vector3 throwDirection = new Vector3(0, 1, 1).normalized;
    [SerializeField]
    float throwSpeed = 6;
    [SerializeField]
    Vector3 startingPos = new Vector3(0, 1f, 0);

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Throw ();
        }
    }

    void Throw()
    {
        Transform potion = Instantiate(potionPrefab);
        potion.transform.position = transform.position + startingPos;
        potion.GetComponent<Rigidbody>().velocity = transform.rotation * (throwSpeed * throwDirection);
    }
}
