using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBreak : MonoBehaviour
{
    [SerializeField]
    Transform breakEffect;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Surface")) {

            Transform effect = Instantiate(breakEffect);
            effect.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            Destroy(gameObject);
        }

    }
}
