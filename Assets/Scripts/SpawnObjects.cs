using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // Referenced https://www.youtube.com/watch?v=1h2yStilBWU for how to make a script that
    // continuously spawns items 
    public GameObject item;
    public bool stopSpawning = false;
    public float yCoord;

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
        // Repeatedly call the function at certain time intervals so it spawns the objects in the level
        InvokeRepeating("spawnItem", spawnTime, spawnDelay);
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the level 
        level = GameObject.FindGameObjectWithTag("Surface");
    }

    public void spawnItem()
    {
        // Taken from the "surface level" script
        // Find a random x coordinate and z coordinae within the level to spawn the item at 
        float xCoord = Random.Range(level.transform.position.x + level.transform.localScale.x * 5, level.transform.position.x - level.transform.localScale.x * 5);
        float zCoord = Random.Range(level.transform.position.z + level.transform.localScale.z * 5, level.transform.position.z - level.transform.localScale.z * 5);
        // Make the y coordinate the same each time the item is spawned
        Vector3 position = new Vector3(xCoord, yCoord, zCoord);
        // When instantiating the item, set the name of the item to the original item name so that it works with the other scripts written
        Instantiate(item, position, transform.rotation).name = item.name;

        // If told to stop spawning items, stop
        if (stopSpawning == true)
        {
            CancelInvoke("spawnItem");
        }
    }
}
