using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // https://learn.unity.com/tutorial/survival-shooter-training-day-phases?projectId=5c514921edbc2a002069465e#5c7f8528edbc2a002053b71e

    public int initialHealth = 50;
    public int currentHealth;

    private bool isDead;
    private bool isDamaged;

    TempMovementScript movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<TempMovementScript>();
        currentHealth = initialHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageTaken(int damageAmount)
    {
        isDamaged = true;
        currentHealth -= damageAmount;

        if (currentHealth <= 0 && !isDead)
        {
            Destroy(this.gameObject);
        }

    }
}
