using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAnimation : MonoBehaviour
{
    // https://www.youtube.com/watch?v=N73EWquTGSY
    public KeyCode key;
    public Image item;
    public Animator itemAnimation;
    public InGameController GC;


    private void Awake()
    {
        itemAnimation = item.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject controller = GameObject.Find("InGameController");
        GC = controller.GetComponent<InGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GC.ingredientsEnabled)
        {
            if (Input.GetKeyDown(key) == true)
            {
                itemAnimation.Play("Movement");
                itemAnimation.StopPlayback();
            }
        }
    }
}
