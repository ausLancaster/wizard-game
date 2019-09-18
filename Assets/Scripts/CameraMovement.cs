using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // https://learn.unity.com/tutorial/camera-and-play-area?projectId=5c51479fedbc2a001fd5bb9f#5c7f8529edbc2a002053b78c
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        
    }
}
