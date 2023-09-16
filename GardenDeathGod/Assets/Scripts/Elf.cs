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

    [Header("Sprites")]
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite elfDestroy;
    [SerializeField]
    private Sprite elfNormal;

    public override void Init()
    {
        gridManager.ClaimTileAt(owner, GetPosX(), GetPosY());
    }

    public override void ExecuteBehaviour()
    {
        gridManager.ClaimTileAt(owner, GetPosX(), GetPosY());
        DoAfterMove();
    }

    public void Handle(Entity target)
    {
        if (target as Gravestone)
        {
            spriteRenderer.sprite = elfDestroy;
            Destroy(target.gameObject);
        }
    }

    public void DoAfterMove()
    {
        spriteRenderer.sprite = elfNormal;
        /*
        for (int i = 0; i < neighbourPositions.Length; i++) {

            EntityUnit unit = gridManager.GetEntityAt(GetPosX() + neighbourPositions[i].x, GetPosY() + neighbourPositions[i].y);
            
            if (unit != null)
            {
                if (unit.GetUnitType() == UnitType.GRAVESTONE)
                {
                    Destroy(unit.gameObject);
                }
            }
        }*/
    }
}
