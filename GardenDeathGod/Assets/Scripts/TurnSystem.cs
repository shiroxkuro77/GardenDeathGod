using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    private void Start()
    {   
        ActivatePlayerTurn();
    }

    public void ActivatePlayerTurn()
    {
        player.startTurn();
    }

    public void ActivateEnemyTurn()
    {
        enemy.startTurn();
    }
}
