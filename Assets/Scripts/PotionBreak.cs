using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionBreak : MonoBehaviour
{
    [SerializeField]
    public InGameController GC;

    Transform effect;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Surface")) {
            
            if (GC.potionQueue[0] == "fire")
            {
                effect = Instantiate(fireBreakEffect);
            }
            else if (GC.potionQueue[0] == "poison")
            {
                effect = Instantiate(poisonBreakEffect);
            }
            else if (GC.potionQueue[0] == "acid")
            {
                effect = Instantiate(acidBreakEffect);
            }
            effect.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            Destroy(gameObject);
            GC.potionQueue.RemoveAt(0);
        }

    }
}
