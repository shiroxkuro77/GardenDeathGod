using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public TurnSystem turnsystem;
    public bool isMyTurn = false;
    
    public void startTurn() {
        Debug.Log("Enemy Start Turn");
        isMyTurn = true;
        //Insert more actions here
        endTurn();
    }
    public void endTurn() {
        Debug.Log("Enemy End Turn");
        isMyTurn = false;
        turnsystem.ActivatePlayerTurn();
    }
    [Header("Deployed Units")]
    [SerializeField]
    private EntityUnit[] units;

    [Header("Components")]
    [SerializeField]
    private GridManager gridManager;

    private void Update()
    {
        UpdatePositions();
    }

    private void UpdatePositions()
    {
        for (int i = 0; i < units.Length; i++)
        {
            gridManager.UpdatePosition(units[i].GetPosX(), units[i].GetPosY(), units[i]);
        }
    }
}
