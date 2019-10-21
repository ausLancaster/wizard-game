using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBehaviour : MonoBehaviour
{

    [SerializeField]
    float amount;
    [SerializeField]
    float periodLength;

    float posY;
    float offset;

    void Start()
    {
        posY = transform.position.y;
    }

    void Update()
    {
        offset = amount * Mathf.Sin((2 * Mathf.PI * Time.time)/periodLength);
        transform.position = new Vector3(
            transform.position.x, 
            posY + offset,
            transform.position.z
            );
    }
}
