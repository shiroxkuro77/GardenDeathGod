using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
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
