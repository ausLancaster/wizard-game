using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clusterGeneration : MonoBehaviour
{
    public GameObject object1;
    public float disperse1;
    public float density1;
    public float sizeVariation1;

    public GameObject object2;
    public float disperse2;
    public float density2;
    public float sizeVariation2;

    public GameObject object3;
    public float disperse3;
    public float density3;
    public float sizeVariation3;

     void Start()
    {
        for(int i=0; i<density1; i++) {
            Vector3 position = new Vector3(Random.Range(-disperse1, disperse1), 0f, Random.Range(-disperse1, disperse1));
            GameObject newObject1 = Instantiate(object1);
            newObject1.transform.parent = this.transform;

            float randomRotation = Random.Range(0, 360);
            float randomScale = Random.Range(1 - sizeVariation1, 1 + sizeVariation1);
            newObject1.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            newObject1.transform.localPosition = position;
            newObject1.transform.localRotation = Quaternion.Euler(0, randomRotation, 0);

        }
        for (int i = 0; i < density2; i++)
        {
            Vector3 position = new Vector3(Random.Range(-disperse2, disperse2), 0f, Random.Range(-disperse2, disperse2));
            GameObject newObject2 = Instantiate(object2);
            newObject2.transform.parent = this.transform;

            float randomRotation = Random.Range(0, 360);
            float randomScale = Random.Range(1 - sizeVariation2, 1 + sizeVariation2);
            newObject2.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            newObject2.transform.localPosition = position;
            newObject2.transform.localRotation = Quaternion.Euler(0, randomRotation, 0);
        }
        for (int i = 0; i < density3; i++)
        {
            Vector3 position = new Vector3(Random.Range(-disperse3, disperse3), 0f, Random.Range(-disperse3, disperse3));
            GameObject newObject3 = Instantiate(object3);
            newObject3.transform.parent = this.transform;

            float randomScale = Random.Range(1 - sizeVariation3, 1 + sizeVariation3);
            float randomRotation = Random.Range(0, 360);
            newObject3.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            newObject3.transform.localPosition = position;
            newObject3.transform.localRotation = Quaternion.Euler(0, randomRotation, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
