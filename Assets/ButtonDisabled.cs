using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisabled : MonoBehaviour
{
    public GameObject player;
    public Text count;

    private Inventory inventory;
    public bool disabled = false;
    private Image shade;

    // Start is called before the first frame update
    void Start()
    {
        inventory = player.GetComponent<Inventory>();
        shade = gameObject.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (count.text == "0")
        {
            disabled = true;
            shade.enabled = true;
        }

        else
        {
            disabled = false;
            shade.enabled = false;
        }
    }
}
