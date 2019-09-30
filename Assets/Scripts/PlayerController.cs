using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 2.0f;
    public float rotationSpeed = 0.15f;


    // Update is called once per frame
    void Update()
    {
        // Player movement and rotation
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 newPos = new Vector3(h, 0.0f, v);

        if (newPos != Vector3.zero)
        {
            // Slerp interpolates the rotation between current rotation and movement rotation for smoother turns
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newPos), rotationSpeed);
            transform.Translate(newPos * moveSpeed * Time.deltaTime, Space.World);
        }

    }
}