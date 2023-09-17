using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        System.Random random = new System.Random();
        for (int i = 0; i < 10; ++i)
        {
            int rx = random.Next(0, gridX);
            int ry = random.Next(0, gridY);
            GameObject go = Instantiate(gravestone);
            Gravestone geu = go.GetComponent<Gravestone>();
            geu.SetOwner(this);
            //go.transform.parent = gameObject.transform;
            units.Add(geu);
            geu.startPosX = rx;
            geu.startPosY = ry;
            //go.transform.position = new Vector3(rx * gridSize, ry * gridSize, 0);
            Debug.Log(units.Count);
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
    private List<EntityUnit> units;

    [Header("Components")]
    [SerializeField]
    private GridManager gridManager;

    private void Update()
    {
        UpdatePositions();
    }

    private void UpdatePositions()
    {
        for (int i = 0; i < units.Count; i++)
        {
            gridManager.UpdatePosition(units[i].GetPosX(), units[i].GetPosY(), units[i]);
        }
    }
}
