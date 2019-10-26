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



    TempMovementScript movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<TempMovementScript>();
        currentHealth = initialHealth;

        slider.value = HealthPercentage();
        Debug.Log(slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = HealthPercentage();
    }

    public void DamageTaken(int damageAmount)
    {
        isDamaged = true;
        currentHealth -= damageAmount;

        slider.value = HealthPercentage();
        Debug.Log(HealthPercentage() + currentHealth + initialHealth);

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
        // https://stackoverflow.com/questions/34436880/function-returns-0-when-float-number-is-under-1/34436912
        // https://www.mvcode.com/lessons/using-sliders-in-unity-aaron
        // https://www.youtube.com/watch?v=ZYeXmze5gxg
        return (float) currentHealth / initialHealth;
    }
}
