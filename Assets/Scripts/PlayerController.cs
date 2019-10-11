using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 2.0f;
    public float rotationSpeed = 0.15f;
    Vector3 newPos;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    public float spinSpeed;
    public bool dying=false;


    public GameObject bloodEffect;


    // Update is called once per frame
    void Update()
    {
        // Only allow player to be controlled when not damaged (i.e when not being knocked back)
        if (knockBackCounter <= 0 && !dying)
        {
            // Player movement and rotation
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            newPos = new Vector3(h, 0.0f, v);
 
        } else
        {
            // Knockback duration countdown
            knockBackCounter -= Time.deltaTime;
        }

        if (newPos != Vector3.zero)
        {
            // Slerp interpolates the rotation between current rotation and movement rotation for smoother turns
            if (knockBackCounter <= 0 && !dying)
            {
                // Only apply rotation to movement when not in knockback mode
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newPos), rotationSpeed);
            }

            if (!dying)
            {
                transform.Translate(newPos * moveSpeed * Time.deltaTime, Space.World);
            }
        }

        if (dying)
        {
            transform.Rotate(0, spinSpeed * Time.deltaTime, 0, Space.World);
        }

    }

    public void Die()
    {
        dying = true;
        GameObject blood = Instantiate(bloodEffect);
        blood.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        Destroy(blood, 3);
        Destroy(gameObject, 3);
    }


    // Determine which direction player is to be knocked back in
    public void KnockBack(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
        newPos = direction * knockBackForce;
        // Tilt player slightly from damage
        newPos.y = knockBackForce;
    }

}
