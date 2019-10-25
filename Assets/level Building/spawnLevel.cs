﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnLevel : MonoBehaviour
{
    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;
    public GameObject Map4;

    public Material floorMaterial1;
    public normalTerrainBuilder foliage1;

    public int level;
    public GameObject blobObject;
    public int incrementBlobOnEachLevel = 2;

    private spawnBlobsOnPlane[] planes;
    private int currentBlobCount;//For keeping track of blobs so when they all die we can open the boos room
    public float mountainDecended = 50;// this is to not let the secret mountain descend forever
    private GameObject secretMountain;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Map;
        float j = Random.Range(0, 4);
        if (j < 1)
            Map = Instantiate(Map1);
        else if (j < 2)
            Map = Instantiate(Map2);
        else if (j < 3)
            Map = Instantiate(Map3);
        else
            Map = Instantiate(Map4);
        Map.transform.parent = transform;
        Map.transform.localPosition = new Vector3(0, 0, 0);

        //Dealing with the planes that does the blob spawning
        planes = Map.GetComponentsInChildren<spawnBlobsOnPlane>();
        for(int i=0; i<planes.Length; i++) {
            planes[i].transform.parent = transform;
            planes[i].ObjectToSpawn = blobObject;
            planes[i].blobCount = incrementBlobOnEachLevel * level;
            planes[i].spawnWaveCount = level;
            planes[i].spawningDuration = level * 3;
        }//------------------------------

        //This loop is just the identify the plane with the "floor" tag
        GameObject surface = new GameObject();
        Transform[] objects = Map.GetComponentsInChildren<Transform>();
        for(int i=0; i< objects.Length; i++) {
            if (objects[i].gameObject.tag == "Surface") {
                surface = objects[i].gameObject;
                surface.GetComponent<MeshRenderer>().material = floorMaterial1;
            }
            if (objects[i].gameObject.tag == "secretMountain")
                secretMountain = objects[i].gameObject;
        }
        //---------------------------------

        //Spawn the foliage on the map
        normalTerrainBuilder foliage = Instantiate(foliage1);
        foliage.plane = surface;
        foliage.BuildTerrain();
        foliage.transform.position = transform.position;
        foliage.transform.parent = transform;

        currentBlobCount = incrementBlobOnEachLevel * level * planes.Length;//initializing the current blob count to the max
        }

    // Update is called once per frame
    void Update()
    {
        if (currentBlobCount < 1 && mountainDecended>0) {
            secretMountain.transform.Translate(new Vector3(0, -Time.deltaTime, 0));
            mountainDecended -= Time.deltaTime;
            level = 1000;
        }
    }

    public void BlobKilled()
    {
        currentBlobCount--;
    }
}