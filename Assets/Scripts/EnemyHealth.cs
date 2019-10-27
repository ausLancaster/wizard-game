using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // https://learn.unity.com/tutorial/survival-shooter-training-day-phases?projectId=5c514921edbc2a002069465e#5c7f8528edbc2a002053b71e

    public int initialHealth = 50;
    public int currentHealth;
    public GameObject healthBar;
    public Slider slider;
    public GameObject blobEye;

    private bool isDead;
    private bool isDamaged;




    // Start is called before the first frame update
    void Start()
    {
        // Make the starting health of the enemy the current health it is at
        currentHealth = initialHealth;

        // Initialise the value of the slider/health bar 
        slider.value = HealthPercentage();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the value of the slider each frame so that enemy health is kept up to date
        slider.value = HealthPercentage();
    }

    public void DamageTaken(int damageAmount)
    {
        isDamaged = true;
        currentHealth -= damageAmount;

        slider.value = HealthPercentage();
        Debug.Log(HealthPercentage() + currentHealth + initialHealth);

        // If the current health of the enemy is either less than or equal to 0, record that the blob
        // has been killed and destroy the blob, as well as spawn the blob eye items for the player to
        // pick up
        if (currentHealth <= 0 && !isDead)
        {
            spawnLevel levelComp = GetComponentInParent<spawnLevel>();
            levelComp.BlobKilled();
            Destroy(this.gameObject);
            Instantiate(blobEye, this.transform.position, this.transform.rotation).name = "Blob eye";
        }

    }

    private float HealthPercentage()
    {
        // Referenced https://stackoverflow.com/questions/34436880/function-returns-0-when-float-number-is-under-1/34436912 for
        // why the value needs to be casted 
        // Referenced https://www.mvcode.com/lessons/using-sliders-in-unity-aaron for how to implement a health bar in Unity
        // Referenced https://www.youtube.com/watch?v=ZYeXmze5gxg for how to make healthbars that are above an enemy's head
        return (float) currentHealth / initialHealth;
    }
}
