using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAnimation : MonoBehaviour
{
    // Referenced https://www.youtube.com/watch?v=N73EWquTGSY for how to play animations when
    // a key is pressed
    // Referenced https://pixelnest.io/tutorials/2d-game-unity/animations-1/ for how to create animatons
    // in unity
    public KeyCode key;
    public Image item;
    public Animator itemAnimation;
    public InGameController GC;
    public Text count;
    public bool animate = true;

    private void Awake()
    {
        // Get the animation component from the game object 
        itemAnimation = item.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find the InGame Controller
        GameObject controller = GameObject.Find("InGameController");
        GC = controller.GetComponent<InGameController>();
        animate = true;
    }

    // Update is called once per frame
    void Update()
    {
        // If ingredients are enabled and the key is pressed animate is true, play the animation then
        // stop the playback, so it only plays the animation once
        if (GC.ingredientsEnabled)
        {
            if (Input.GetKeyDown(key) == true && animate==true)
            {
                itemAnimation.Play("Movement");
                itemAnimation.StopPlayback();
            }
        }

        // Do not animate if count is 0
        if (string.Compare(count.text, "0") == 0)
        {
            animate = false;
        } else
        {
            animate = true;
        }

    }
}
