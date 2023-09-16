using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : EntityUnit
{
    private readonly Vector3Int[] neighbourPositions =
    {
        Vector3Int.up,
        Vector3Int.right,
        Vector3Int.down,
        Vector3Int.left,
        Vector3Int.up + Vector3Int.right,
        Vector3Int.up + Vector3Int.left,
        Vector3Int.down + Vector3Int.right,
        Vector3Int.down + Vector3Int.left
    };

    public void DoAfterMove()
    {
        for (int i = 0; i < neighbourPositions.Length; i++) {

            EntityUnit unit = gridManager.GetEntityAt(GetPosX() + neighbourPositions[i].x, GetPosY() + neighbourPositions[i].y);
            
            if (unit != null)
            {
                if (unit.GetUnitType() == UnitType.GRAVESTONE)
                {
                    Destroy(unit.gameObject);
                }
            }
        }
    }
}
