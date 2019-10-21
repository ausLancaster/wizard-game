using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobbingBehaviour : MonoBehaviour
{

    [SerializeField]
    float amount;
    [SerializeField]
    float periodLength;

    Vector3 baseScale;

    void Start()
    {
        baseScale = transform.localScale;
    }

    void Update()
    {
        Vector3 scaleAmount = new Vector3(
            amount + 1 + amount * Mathf.Sin((2 * Mathf.PI * Time.time) / periodLength),
            1,
            amount + 1 + amount * Mathf.Sin((2 * Mathf.PI * Time.time + Mathf.PI) / periodLength)
            );

        transform.localScale = Vector3.Scale(baseScale, scaleAmount);
    }
}
