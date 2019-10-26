using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPotion : MonoBehaviour
{
    [SerializeField]
    Transform potionPrefab;
    [SerializeField]
    Transform target;
    [SerializeField]
    Vector3 throwDirection = new Vector3(0, 1, 1).normalized;
    [SerializeField]
    float throwSpeedMin = 5;
    [SerializeField]
    float throwSpeedMax = 12;
    [SerializeField]
    float throwDistanceMin = 1.6f;
    [SerializeField]
    float throwDistanceMax = 7.7f;
    [SerializeField]
    float increaseSpeed = 1;
    [SerializeField]
    float cooldownAmount = 1;
    [SerializeField]
    float spinSpeedMin = 2;
    [SerializeField]
    float spinSpeedMax = 6;
    [SerializeField]
    float maxAimTime = 1;
    Vector3 startingPos = new Vector3(0, 1f, 0);
    float cooldownTimer;
    bool increasing;
    float aimAmount=-1;
    float targetY;
    
    public InGameController GC;
    
    void Start()
    {
        cooldownTimer = cooldownAmount;
        target.gameObject.SetActive(false);
        targetY = target.position.y;
    }

    void Update()
    {
        print(increasing);
        print(aimAmount);
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (aimAmount >= 0)
        {
            if (increasing)
            {
                aimAmount += Time.deltaTime;
                if (aimAmount > maxAimTime)
                {
                    increasing = false;
                    aimAmount = maxAimTime;
                }
            }
            else
            {
                aimAmount -= Time.deltaTime;
                if (aimAmount <= 0)
                {
                    increasing = true;
                    aimAmount = 0;
                }
            }

        }
        if (cooldownTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GC.numPotions > 0)
                {
                    print("aim " + target.gameObject);
                    target.gameObject.SetActive(true);
                    aimAmount = 0;
                    increasing = true;
                } else if (GC.numPotions == 0) {
                    GC.NoPotionMessage();
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.E) && cooldownTimer <= 0 && target.gameObject.activeSelf)
        {
            print("throw");
            Throw();
            target.gameObject.SetActive(false);
            aimAmount = -10;
            cooldownTimer = cooldownAmount;
        }
        target.localPosition = new Vector3(0, targetY, Mathf.Lerp(throwDistanceMin, throwDistanceMax, aimAmount / maxAimTime));
        target.position = new Vector3(target.position.x, targetY, target.position.z);
    }

    void Throw()
    {
        print("aim amount: " + aimAmount);
        Transform potion = Instantiate(potionPrefab);
        potion.transform.position = transform.position + startingPos;
        Rigidbody potionRB = potion.GetComponent<Rigidbody>();
        float throwSpeed = Mathf.Lerp(throwSpeedMin, throwSpeedMax, aimAmount / maxAimTime);
        potionRB.velocity = transform.rotation * (throwSpeed * throwDirection);
        print("velocity: " + potionRB.velocity);
        float a = Random.value * 2 * Mathf.PI;
        potionRB.angularVelocity = Random.Range(spinSpeedMin, spinSpeedMax) * new Vector3(Mathf.Cos(a), 0, Mathf.Sin(a));
        potion.rotation = Random.rotation;

    }
}
