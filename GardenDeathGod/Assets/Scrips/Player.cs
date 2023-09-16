using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using TMPro; 

public class Player : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public TurnSystem turnsystem;
    public int playerPoints;
    public bool isMyTurn = false;
    private enum PlayerState { IDLE, SELECT_UNIT, AWAIT_ACTION, AWAIT_UNIT_MOVE };
    private enum SelectedEntity { TILE, PLAYER_UNIT, ENEMY };
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

    private void selectUnit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = PlayerSelect();
            if (hit.collider != null)
            {
                selectedEntity = hit.collider.gameObject.GetComponent<Entity>();
                if (selectedEntity as PlayerUnit) selectedEntityType = SelectedEntity.PLAYER_UNIT;
                if (selectedEntity as Enemy) selectedEntityType = SelectedEntity.ENEMY;
                if (selectedEntity as GridItem) selectedEntityType = SelectedEntity.TILE;

                playerState = PlayerState.AWAIT_ACTION;
            }
        }
    }

    private void AwaitAction()
    {
        switch (selectedEntityType)
        {
            case SelectedEntity.PLAYER_UNIT:
                playerState = PlayerState.AWAIT_UNIT_MOVE;
                break;
            case SelectedEntity.ENEMY:
                break;
            case SelectedEntity.TILE:
                break;
        }
    }

    private void AwaitUnitMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = PlayerSelect();
            if (hit.collider != null)
            {
                Entity target = hit.collider.gameObject.GetComponent<Entity>();
                if (target as GridItem)
                {
                    GridItem gridItem = (GridItem)target;
                    PlayerUnit p = selectedEntity as PlayerUnit;
                    p.MoveTo(gridItem.GetX(), gridItem.GetY());

                    playerState = PlayerState.IDLE;
                }
            }
        }
    }

    private RaycastHit PlayerSelect()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity);

        return hit;
    }

    public void startTurn() {
        Debug.Log("Player Start Turn");
        isMyTurn = true;
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
