using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionCollision : MonoBehaviour
{
    public InGameController GC;
    public GameObject potion;
    EnemyHealth enemyHealth;

    private void Awake()
    {
        // Get the health of the enemy and InGame Controller at start 
        enemyHealth = GetComponent<EnemyHealth>();
        GC = GameObject.Find("InGameController").GetComponent<InGameController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Referenced https://learn.unity.com/tutorial/collecting-scoring-and-building-the-game?projectId=5c51479fedbc2a001fd5bb9f#5c7f8529edbc2a002053b78b
        // for how to inflict damage on an enemy when it comes into contact with a potion explosion 

        // If the game object is a potion, deal damage to the enemy 
        if (other.gameObject.CompareTag("Potion"))
        {
            // Increase the damage taken by the enemy if the amount of damage the potion inflicts has been increased
            if (GC.damageIncreased)
            {
                enemyHealth.DamageTaken(50);
            } else
            {
                enemyHealth.DamageTaken(25);
            }
            // Reset the damage increase for the next potion 
            GC.damageIncreased = false;
        }
    }
}
