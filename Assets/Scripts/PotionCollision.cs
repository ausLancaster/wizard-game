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
        // https://learn.unity.com/tutorial/collecting-scoring-and-building-the-game?projectId=5c51479fedbc2a001fd5bb9f#5c7f8529edbc2a002053b78b
        if (other.gameObject.CompareTag("Potion"))
        {
            //this.gameObject.SetActive(false);
            // https://answers.unity.com/questions/176001/destroy-on-collision.html
            //Destroy(this.gameObject);
            //Debug.Log("collision detected");
            if (GC.damageIncreased)
            {
                enemyHealth.DamageTaken(50);
            } else
            {
                enemyHealth.DamageTaken(25);
            }          
        }
    }
}
