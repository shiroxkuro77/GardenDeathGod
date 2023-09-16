using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityUnit : Entity
{
    [Header("Components")]
    [SerializeField]
    private GridManager gridManager;
    [SerializeField]
    private Entity owner;

    [Header("Settings")]
    [SerializeField]
    private UnitType unitType;
    private enum UnitType { ELF };
    [SerializeField]
    private int startPosX;
    [SerializeField]
    private int startPosY;
    [SerializeField]
    private int maxMovementX;
    [SerializeField]
    private int maxMovementY;

    [Header("States")]
    [SerializeField]
    private int currPosX;
    [SerializeField]
    private int currPosY;

    // Start is called before the first frame update
    private void Start()
    {
        MoveTo(startPosX, startPosY);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetPosX()
    {
        return currPosX;
    }

    public int GetPosY()
    {
        return currPosY;
    }

    public int GetMaxX()
    {
        return maxMovementX;
    }

    public int GetMaxY()
    {
        return maxMovementY;
    }

    public void MoveTo(int x, int y)
    {
        transform.position = gridManager.GetPosOfGrid(x, y);
        currPosX = x;
        currPosY = y;
    }

    public void ExecuteBehaviour()
    {
        switch(unitType)
        {
            case UnitType.ELF:
                ElfBehaviour();
                break;
        }
    }

    public void ElfBehaviour()
    {
        gridManager.ClaimTileAt(owner, currPosX, currPosY);
    }
}
