using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // https://www.youtube.com/watch?v=1h2yStilBWU
    public GameObject item;
    public bool stopSpawning = false;
    //public float spawnTimeMin;
    //public float spawnTimeMax;
    //public float spawnDelayMin;
    //public float spawnDelayMax;

    public float spawnTime;
    public float spawnDelay;
    public GameObject level;
    private GameObject spawnedItem;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
        //spawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
        for (int i = 0; i < 50; i++)
        {
            spawnItem();
            Debug.Log("test");
        }

        InvokeRepeating("spawnItem", spawnTime, spawnDelay);
        
    }

    // Update is called once per frame
    void Update()
    {
        level = GameObject.FindGameObjectWithTag("Surface");
    }

    public void spawnItem()
    {
        float xCoord = Random.Range(level.transform.position.x + level.transform.localScale.x * 5, level.transform.position.x - level.transform.localScale.x * 5);
        float zCoord = Random.Range(level.transform.position.z + level.transform.localScale.z * 5, level.transform.position.z - level.transform.localScale.z * 5);
        Vector3 position = new Vector3(xCoord, 0, zCoord);
        Instantiate(item, position, transform.rotation).name = item.name;

        if (stopSpawning == true)
        {
            CancelInvoke("spawnItem");
        }
    }
}
