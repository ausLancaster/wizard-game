using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageAmount;
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
        if (other.gameObject.tag == "Player")
        {
            // Find out the direction player hit from and knock them back in the reverse direction
            Vector3 collisionDirection = other.transform.position - transform.position;
            collisionDirection = collisionDirection.normalized;
            FindObjectOfType<HealthManager>().DamagePlayer(damageAmount, collisionDirection);
        }
    }
}
