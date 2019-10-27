using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobbingBehaviour : MonoBehaviour
{

    [SerializeField]
    float amount;
    [SerializeField]
    float periodLength;

    Vector3 baseScale1;
    Vector3 baseScale2;
    Vector3 baseScale3;

    void Start()
    {
        baseScale1 = transform.GetChild(0).gameObject.transform.localScale;
        baseScale2 = transform.GetChild(1).gameObject.transform.localScale;
        baseScale3 = transform.GetChild(2).gameObject.transform.localScale;
    }

    void Update()
    {
        Vector3 scaleAmount = new Vector3(
            amount + 1 + amount * Mathf.Sin((2 * Mathf.PI * Time.time) / periodLength),
            1,
            amount + 1 + amount * Mathf.Sin((2 * Mathf.PI * Time.time + Mathf.PI) / periodLength)
            );
        // Apply the blobbing behaviour to all the objects that make up the blob separately
        // so that the enemy health bars are not affected by the transformation as well
        transform.GetChild(0).gameObject.transform.localScale = Vector3.Scale(baseScale1, scaleAmount);
        transform.GetChild(1).gameObject.transform.localScale = Vector3.Scale(baseScale2, scaleAmount);
        transform.GetChild(2).gameObject.transform.localScale = Vector3.Scale(baseScale3, scaleAmount);
    }
}
