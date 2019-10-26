using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // https://www.youtube.com/watch?v=1h2yStilBWU
    public GameObject item;
    public bool stopSpawning = false;
    private float spawnTime;
    private float spawnDelay;

    private GameObject spawnedItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = Random.Range(1, 50);
        spawnDelay = Random.Range(70, 130);
        InvokeRepeating("spawnItem", spawnTime, spawnDelay);
        
    }

    public void spawnItem()
    {
        float xCoord = Random.Range(transform.position.x + transform.localScale.x * 5, transform.position.x - transform.localScale.x * 5);
        float zCoord = Random.Range(transform.position.z + transform.localScale.z * 5, transform.position.z - transform.localScale.z * 5);
        Vector3 position = new Vector3(xCoord, 0, zCoord);
        Instantiate(item, position, transform.rotation).name = item.name;

        if (stopSpawning == true)
        {
            CancelInvoke("spawnItem");
        }
    }
}
