using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityUnit : Entity
{
    [Header("Components")]
    [SerializeField]
    protected GridManager gridManager;

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
    protected void Start()
    {
        currPosX = startPosX;
        currPosY = startPosY;
        MoveTo(startPosX, startPosY);
    }

    public abstract void Init();

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

    public void SetGridManager(GridManager gridManager)
    {
        this.gridManager = gridManager;
    }

    public abstract void ExecuteBehaviour();
}
