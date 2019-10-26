using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBreak : MonoBehaviour
{
    [SerializeField]
    public InGameController GC;

    Transform effect;
    Transform effect1;
    Transform effect2;
    public Transform fireBreakEffect;
    public Transform poisonBreakEffect;
    public Transform acidBreakEffect;

    void Start()
    {
        GameObject controller = GameObject.Find("InGameController");
        GC = controller.GetComponent<InGameController>();
    }

    void Update()
    {

    }

    // More esplosions if powered up by egg
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Surface")) {
            
            if (GC.potionQueue[0] == "fire")
            {
                effect = Instantiate(fireBreakEffect);
                effect.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                if (GC.explosionIncreased)
                {
                    effect1 = Instantiate(fireBreakEffect);
                    effect1.transform.position = new Vector3(transform.position.x + 1.5f, 0, transform.position.z + 1.5f);
                    effect2 = Instantiate(fireBreakEffect);
                    effect2.transform.position = new Vector3(transform.position.x - 1.5f, 0, transform.position.z + 1.5f);
                }
            }
            else if (GC.potionQueue[0] == "poison")
            {
                effect = Instantiate(poisonBreakEffect);
                effect.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                if (GC.explosionIncreased)
                {
                    effect1 = Instantiate(poisonBreakEffect);
                    effect1.transform.position = new Vector3(transform.position.x + 1.5f, 0, transform.position.z + 1.5f);
                    effect2 = Instantiate(poisonBreakEffect);
                    effect2.transform.position = new Vector3(transform.position.x - 1.5f, 0, transform.position.z + 1.5f);
                }
            }
            else if (GC.potionQueue[0] == "acid")
            {
                effect = Instantiate(acidBreakEffect);
                effect.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                if (GC.explosionIncreased)
                {
                    effect1 = Instantiate(acidBreakEffect);
                    effect1.transform.position = new Vector3(transform.position.x + 1.5f, 0, transform.position.z + 1.5f);
                    effect2 = Instantiate(acidBreakEffect);
                    effect2.transform.position = new Vector3(transform.position.x - 1.5f, 0, transform.position.z + 1.5f);
                }
            }
            Destroy(gameObject);
            GC.potionQueue.RemoveAt(0);
            GC.explosionIncreased = false;
        }

    }
}
