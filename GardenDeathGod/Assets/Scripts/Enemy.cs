using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public TurnSystem turnsystem;
    public bool isMyTurn = false;
    public int gridX;
    public int gridY;
    public int gridSize;
    [SerializeField]
    private GameObject gravestone;

    public void startTurn() {
        Debug.Log("Enemy Start Turn");
        isMyTurn = true;
        for(int i = 0; i < 10; ++i)
        {
            System.Random random = new System.Random();
            int rx = random.Next(0, gridX);
            int ry = random.Next(0, gridY);
            GameObject go = Instantiate(gravestone);
            go.transform.parent = gameObject.transform;
            go.transform.position = new Vector3(rx * gridSize, ry * gridSize, 0);
            Debug.Log(rx);
        }
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
