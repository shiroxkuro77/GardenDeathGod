using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnBtn : MonoBehaviour
{
    public Player player;
    // Update is called once per frame
    void Update()
    {   // Check for left mouse button click
        if (Input.GetMouseButtonDown(0) && player.isMyTurn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Cast a ray from the mouse position
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction); // Perform the raycast

            if (hit.collider != null && hit.collider.gameObject == gameObject) // Check if the ray hits the sprite
            {
                player.endTurn();
            }
                    
        }
    }
}
