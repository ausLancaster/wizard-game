using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    private EnemyHealth healthComp;
    private const float SIZEOVERHEALTH = 0.05f;// determines how big the boss will look like compared to its health

    private float maxHealth;
    public int remainingWaves = 3;
    public int minionCountOnEachWave = 2;
    public GameObject minion;
    // Start is called before the first frame update
    void Start()
    {
        healthComp = gameObject.GetComponent<EnemyHealth>();
        transform.localScale = new Vector3(healthComp.currentHealth * SIZEOVERHEALTH, healthComp.currentHealth * SIZEOVERHEALTH, healthComp.currentHealth * SIZEOVERHEALTH);
        maxHealth = healthComp.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //This part is to give the change in the boss' scale an acceleration effect
        //instead of just setting the acceleration value whic makes it a little bit smoother
        float currentSize = transform.localScale.x;
        float desiredSize = healthComp.currentHealth * SIZEOVERHEALTH;
        if (Mathf.Abs(currentSize - desiredSize) <= 0.02f)
            currentSize = desiredSize;
        if (desiredSize < currentSize) 
        {
            if ((currentSize - desiredSize) * 0.1f > 0.02f)
                currentSize = currentSize - ((currentSize - desiredSize) * 0.1f);
            else
                currentSize -= 0.02f;
        } 
        else if(desiredSize > currentSize)
        {
            if ((desiredSize - currentSize) * 0.1f > 0.02f)
                currentSize = currentSize + ((desiredSize - currentSize) * 0.1f);
            else
                currentSize += 0.02f;
        }
        transform.localScale = new Vector3(currentSize, currentSize, currentSize);
        // ------  ends here ---------


        if(healthComp.currentHealth <= maxHealth * ((remainingWaves - 1) / (float)(remainingWaves)) && healthComp.currentHealth>0) {
            spawnWave();
            maxHealth = maxHealth * ((remainingWaves - 1) / (float)(remainingWaves));
            remainingWaves--;
        }
    }

    void spawnWave() { 
        for(int i=0; i<minionCountOnEachWave; i++) {
            GameObject currentMinion = Instantiate(minion);
            float xCoord = transform.position.x + 5;
            float zCoord = transform.position.z + 5;
            currentMinion.transform.position = new Vector3(xCoord, 0, zCoord);
        }
    }
}
