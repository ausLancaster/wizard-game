using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//!!!This script assumes the lpane is not rotated and the plane is a normal 5 by 5 plane when the scale is 1
public class spawnBlobsOnPlane : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public int blobCount;
    public int spawnWaveCount;
    public float spawningDuration;

    private float time = 0;
    private float spawnAfter;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnAfter = spawningDuration / spawnWaveCount;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time <= spawningDuration + 1 && time >= spawnAfter) {
            spawnAfter += spawningDuration / spawnWaveCount;
            for (int i = 0; i < blobCount / spawnWaveCount; i++)
            {
                float xCoord = Random.Range(transform.position.x + transform.localScale.x * 5, transform.position.x - transform.localScale.x * 5);
                float zCoord = Random.Range(transform.position.z + transform.localScale.z * 5, transform.position.z - transform.localScale.z * 5);
                GameObject spawnedObject = Instantiate(ObjectToSpawn);
                spawnedObject.transform.position = new Vector3(xCoord, 0, zCoord);
                spawnedObject.transform.parent = transform;
            }
        }

    }
}
