using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead = false;
    public UnityEvent zeroHealthEvent;
    public float sceneDelay = 3;
    public Slider healthbar;

    public float invincibilityLength = 3;
    private float invincibilityCounter;

    public Renderer playerBodyRenderer;
    public float flashLength = 0.1f;
    private float flashCounter;

    // For healing player animation
    public Camera mainCamera;
    public Camera healingCamera;
    public GameObject healthPotion;
    public GameObject healthBottle;
    public Animator healAnimation;
    public GameObject healedText;
    public int healthPotionCount;
    public bool isHealing;
    public float healingDuration;

    // Start is called before the first frame update
    void Start()
    {
        this.ResetHealthToStarting();
        healthbar.value = (float) currentHealth / maxHealth;
        healthPotionCount = 0;
        healthPotion = GameObject.Find("HealthPotion");

        mainCamera.enabled = true;
        healingCamera.enabled = false;
        healthPotion.SetActive(false);
        healthBottle.SetActive(false);
        healAnimation = healthBottle.GetComponent<Animator>();
        isHealing = false;
        healingDuration = 2.0f;
        healedText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = (float) currentHealth / maxHealth;
        // Show health potion inventory if available
        if (healthPotionCount>0)
        {
            healthPotion.SetActive(true);
            healthPotion.GetComponentInChildren<Text>().text = healthPotionCount.ToString();
        } else if (healthPotionCount<=0)
        {
            healthPotion.SetActive(false);
        }

        // Use health potions if available
        if (Input.GetKeyDown(KeyCode.H) && healthPotionCount>0)
        {
            isHealing = true;
            healthBottle.SetActive(false);
            healthPotionCount--;

        }

        // Play animation and messages when healing
        if (isHealing)
        {
            if (healingDuration >= 0)
            {
                healingDuration -= Time.deltaTime;
                mainCamera.enabled = false;
                healingCamera.enabled = true;
                healedText.SetActive(true);
                healthBottle.SetActive(true);
                healAnimation.Play("Movement");
            }
            else if (healingDuration < 0)
            {
                healthBottle.SetActive(false);
                mainCamera.enabled = true;
                healingCamera.enabled = false;
                healedText.SetActive(false);
                healingDuration = 2.0f;
                isHealing = false;
            }

        }


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

        // Kill player once health runs out
        if (currentHealth <=0 && isDead==false)
        {
            KillPlayer();
        }

        // Delay the loading of GameOver scene
        if (isDead)
        {
            sceneDelay -= Time.deltaTime;
            if (sceneDelay <= 0)
            {
                this.zeroHealthEvent.Invoke();
            }
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
        isDead = true;
        // Play player death action
        this.gameObject.GetComponent<PlayerController>().Die();
    }

    // Getter function for private health variable
    public int GetHealth()
    {
        return this.currentHealth;
    }
}
