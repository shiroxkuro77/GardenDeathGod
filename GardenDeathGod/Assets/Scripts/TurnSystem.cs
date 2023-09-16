using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject uiElement;

    private bool isPlayerTurn = true;

    private void Start()
    {   
        if (uiElement != null)
        {
            uiElement.SetActive(true);
        }
        // Start with the player's turn
        ActivatePlayerTurn();
    }

    private void Update()
    {
        // Check if the current turn is over (e.g., player or enemy action completed)
        if (IsTurnOver())
        {
            // Toggle the turn
            isPlayerTurn = !isPlayerTurn;

            // Activate the next turn
            if (isPlayerTurn)
            {
                ActivatePlayerTurn();
            }
            else
            {
                ActivateEnemyTurn();
            }
        }
    }

    private bool IsTurnOver()
    {
        // Implement your logic here to determine if a turn is over
        // For simplicity, you can use a timer, user input, or other conditions.
        // You might need to handle input or actions specific to your game.
        return true; // Change this to your actual condition.
    }

    private void ActivatePlayerTurn()
    {
        player.SetActive(true);
        enemy.SetActive(false);
    }

    private void ActivateEnemyTurn()
    {
        player.SetActive(false);
        enemy.SetActive(true);
    }
}
