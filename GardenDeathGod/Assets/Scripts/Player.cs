using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.UI; 

public class Player : Entity
{
    public Text pointText;
    public TurnSystem turnsystem;
    public int playerPoints;
    public bool isMyTurn = false;
    private enum PlayerState { IDLE, SELECT_UNIT, AWAIT_ACTION, AWAIT_UNIT_MOVE };
    private enum SelectedEntity { TILE, ENTITY };
    [Header("States")]
    [SerializeField]
    private PlayerState playerState;
    [SerializeField]
    private SelectedEntity selectedEntityType;
    [SerializeField]
    private Entity selectedEntity;

    [Header("Components")]
    [SerializeField]
    private GridManager gridManager;
    private void Start() {
        updatePoints(0);
    }

    [Header("Deployed Units")]
    [SerializeField]
    private EntityUnit[] units;
    private void Update()
    {
        switch (playerState)
        {
            case PlayerState.IDLE:
                break;
            case PlayerState.SELECT_UNIT:
                selectUnit();
                break;
            case PlayerState.AWAIT_ACTION:
                AwaitAction();
                break;
            case PlayerState.AWAIT_UNIT_MOVE:
                AwaitUnitMove();
                break;
        }
    }

    // Select Tile or Entity
    private void selectUnit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = PlayerSelect();
            if (hit.collider != null)
            {
                selectedEntity = hit.collider.gameObject.GetComponent<Entity>();
                if (selectedEntity as EntityUnit) selectedEntityType = SelectedEntity.ENTITY;
                if (selectedEntity as GridItem) selectedEntityType = SelectedEntity.TILE;

                playerState = PlayerState.AWAIT_ACTION;
            }
        }
    }

    // Await action after selecting tile or entity.
    private void AwaitAction()
    {
        switch (selectedEntityType)
        {
            case SelectedEntity.ENTITY:
                if (selectedEntity.GetOwner() == this)
                {
                    if (selectedEntity as Elf) playerState = PlayerState.AWAIT_UNIT_MOVE;
                }
                else
                    playerState = PlayerState.SELECT_UNIT;
                break;
            case SelectedEntity.TILE:
                break;
        }
    }

    // Await user select target destination
    private void AwaitUnitMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = PlayerSelect();
            if (hit.collider != null)
            {
                Entity target = hit.collider.gameObject.GetComponent<Entity>();

                // Move to tile
                if (target as GridItem)
                {
                    GridItem gridItem = (GridItem)target;
                    EntityUnit p = selectedEntity as EntityUnit;

                    // Check if valid move.
                    if (Mathf.Abs(gridItem.GetX() - p.GetPosX()) <= p.GetMaxX() &&
                        Mathf.Abs(gridItem.GetY() - p.GetPosY()) <= p.GetMaxY())
                    {
                        p.MoveTo(gridItem.GetX(), gridItem.GetY());
                        p.ExecuteBehaviour();
                        playerState = PlayerState.IDLE;
                    }
                }

                // Obstacles
                if (target as Gravestone)
                {
                    if (selectedEntity as Elf)
                    {
                        ((Elf)selectedEntity).Handle(target);
                    }
                }
            }
        }
    }
    
    // Player mouse click select
    private RaycastHit2D PlayerSelect()
    {
        return Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
    }

    public void startTurn() {
        Debug.Log("Player Start Turn");
        isMyTurn = true;
        int numOfGrass = gridManager.numberOfGrass();
        updatePoints(numOfGrass);
    }
    public void endTurn() {
        Debug.Log("Player End Turn");
        isMyTurn = false;
        turnsystem.ActivateEnemyTurn();
    }

    public void updatePoints(int addpoints) {

        playerPoints += addpoints;
        pointText.text = playerPoints.ToString();

    }
}
