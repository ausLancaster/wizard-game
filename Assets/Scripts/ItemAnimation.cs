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


    private void Awake()
    {
        itemAnimation = item.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) == true)
        {
            itemAnimation.Play("Movement");
            itemAnimation.StopPlayback();
        } 
    }
}
