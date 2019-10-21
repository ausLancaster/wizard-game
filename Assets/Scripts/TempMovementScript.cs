using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovementScript : MonoBehaviour
{
    // Code from lab 2
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            this.transform.localPosition += new Vector3(0.0f, 0.0f, 1.0f) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            this.transform.localPosition += new Vector3(0.0f, 0.0f, -1.0f) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            this.transform.localPosition += new Vector3(1.0f, 0.0f, 0.0f) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            this.transform.localPosition += new Vector3(-1.0f, 0.0f, 0.0f) * speed * Time.deltaTime;
        }

    }
}
