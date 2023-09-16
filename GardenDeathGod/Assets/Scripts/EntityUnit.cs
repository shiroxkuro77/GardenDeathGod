using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityUnit : Entity
{
    [Header("Components")]
    [SerializeField]
    private GridManager gridManager;

    [Header("Settings")]
    [SerializeField]
    private UnitType unitType;
    public enum UnitType { ELF, GRAVESTONE };
    [SerializeField]
    private int startPosX;
    [SerializeField]
    private int startPosY;

    [Header("Movement Behaviour")]
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

        switch (unitType) { 
            case UnitType.ELF:
                InitElf();
                break;
        }
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
        Vector3 gridPos = gridManager.GetPosOfGrid(x, y);
        transform.position = new Vector3(gridPos.x, gridPos.y, transform.position.z);
        currPosX = x;
        currPosY = y;
    }
    
    public UnitType GetUnitType()
    {
        return unitType;
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

    private void ElfBehaviour()
    {
        gridManager.ClaimTileAt(owner, currPosX, currPosY);
    }

    private void InitElf()
    {
        gridManager.ClaimTileAt(owner, currPosX, currPosY);
    }
}
