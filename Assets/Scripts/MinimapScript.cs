using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
	public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Referenced https://blog.theknightsofunity.com/implementing-minimap-unity/ for how to create a
    // minimap for a game
    // Referenced https://www.youtube.com/watch?v=28JTTXqMvOU for how to get the minimap
    // to follow the player around the map 
    void LateUpdate()
	{
        // Follow the player's posiiton while keeping the y coordinate constant
        Vector3 newPosition = player.position;
		newPosition.y = transform.position.y;
		transform.position = newPosition;
	}
}
