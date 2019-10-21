using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalTerrainBuilder : MonoBehaviour
{
    public GameObject plane;

    public clusterGeneration cluster1;
    public int clusterCount1;

    public clusterGeneration cluster2;
    public int clusterCount2;

    public clusterGeneration cluster3;
    public int clusterCount3;

    public clusterGeneration cluster4;
    public int clusterCount4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildTerrain() {
        float border = plane.transform.localScale.x * 4;
        for (int i = 0; i < clusterCount1; i++)
        {
            clusterGeneration cluster = Instantiate(cluster1);
            cluster.transform.parent = this.transform;
            cluster.transform.localPosition = new Vector3(Random.Range(-border, border), 0, Random.Range(-border, border));
        }
        for (int i = 0; i < clusterCount2; i++)
        {
            clusterGeneration cluster = Instantiate(cluster2);
            cluster.transform.parent = this.transform;
            cluster.transform.localPosition = new Vector3(Random.Range(-border, border), 0, Random.Range(-border, border));
        }
        for (int i = 0; i < clusterCount3; i++)
        {
            clusterGeneration cluster = Instantiate(cluster3);
            cluster.transform.parent = this.transform;
            cluster.transform.localPosition = new Vector3(Random.Range(-border, border), 0, Random.Range(-border, border));
        }
        for (int i = 0; i < clusterCount4; i++)
        {
            clusterGeneration cluster = Instantiate(cluster4);
            cluster.transform.parent = this.transform;
            cluster.transform.localPosition = new Vector3(Random.Range(-border, border), 0, Random.Range(-border, border));
        }
    }
}
