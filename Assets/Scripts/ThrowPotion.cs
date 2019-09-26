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
    float throwSpeed = 10;
    [SerializeField]
    float cooldownAmount = 1;
    [SerializeField]
    float spinSpeedMin = 2;
    [SerializeField]
    float spinSpeedMax = 6;
    Vector3 startingPos = new Vector3(0, 1f, 0);
    float cooldownTimer;
    bool canThrow = true;
    
    void Start()
    {
        cooldownTimer = cooldownAmount;
    }

    void Update()
    {
        if (!canThrow)
        {
            if (cooldownTimer <= 0)
            {
                canThrow = true;
            }
            else
            {
                cooldownTimer -= Time.deltaTime;
            }

        }

        if (Input.GetKeyDown(KeyCode.E) && canThrow)
        {
            Throw ();
            canThrow = false;
            cooldownTimer = cooldownAmount;
        }
    }

    void Throw()
    {
        Transform potion = Instantiate(potionPrefab);
        potion.transform.position = transform.position + startingPos;
        Rigidbody potionRB = potion.GetComponent<Rigidbody>();
        potionRB.velocity = transform.rotation * (throwSpeed * throwDirection);
        float a = Random.value * 2 * Mathf.PI;
        potionRB.angularVelocity = Random.Range(spinSpeedMin, spinSpeedMax) * new Vector3(Mathf.Cos(a), 0, Mathf.Sin(a));
        potion.rotation = Random.rotation;
    }
}
