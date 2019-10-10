using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invincibilityLength = 3;
    private float invincibilityCounter;

    public Renderer playerBodyRenderer;
    public float flashLength = 0.1f;
    private float flashCounter;

    // Start is called before the first frame update
    void Start()
    {
        this.ResetHealthToStarting();
    }

    // Update is called once per frame
    void Update()
    {
        // Player only flashes when invincible
        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;


            if (flashCounter <= 0)
            {
                playerBodyRenderer.enabled = !playerBodyRenderer.enabled;
                flashCounter = flashLength;
            }
            if (invincibilityCounter <= 0)
            {
                // Loop won't run again, so must ensure player is rendered
                playerBodyRenderer.enabled = true;
            }
        }

        if (currentHealth <=0)
        {
            KillPlayer();
        }
    }

    private void ResetHealthToStarting()
    {
        currentHealth = maxHealth;
    }

    public void DamagePlayer(int damageAmount, Vector3 direction)
    {
        if (invincibilityCounter <= 0)
        {
            // Reduce player health and knock them back
            currentHealth -= damageAmount;
            this.gameObject.GetComponent<PlayerController>().KnockBack(direction);

            // Make player invincible
            invincibilityCounter = invincibilityLength;

            // Start flashing
            playerBodyRenderer.enabled = false;
            flashCounter = flashLength;
        }

    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void KillPlayer()
    {
        this.gameObject.GetComponent<PlayerController>().isDead = true;
    }

    // Getter function for private health variable
    public int GetHealth()
    {
        return this.currentHealth;
    }
}
