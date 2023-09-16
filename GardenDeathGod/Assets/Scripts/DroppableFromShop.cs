using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppableFromShop : MonoBehaviour
{
    public int pointCost;
    public Player player;
    public GridManager gridManager;
    public GameObject draggableObjectPrefab; // Reference to the draggable object prefab
    private GameObject currentDraggableObject;
    private EntityUnit currentDraggableEntity;
    private bool isDragging = false;
    private Vector3 offset;

    public enum DraggableUnitType { DEFAULT, ELF };
    [SerializeField]
    private DraggableUnitType draggableUnitType;

    void Update()
    {

        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0) && player.isMyTurn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Cast a ray from the mouse position
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction); // Perform the raycast

            if (hit.collider != null && hit.collider.gameObject == gameObject) // Check if the ray hits the sprite
            {
                if (player.playerPoints >= pointCost) {
                    // Handle the collision with the specific object here
                    SpawnNewDraggableObject();
                    player.updatePoints(-pointCost);
                }
            }
                    
        }

        // Handle dragging of the spawned object
        if (isDragging && currentDraggableObject != null)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            currentDraggableObject.transform.position = new Vector3(newPosition.x, newPosition.y, currentDraggableObject.transform.position.z);
        }

        // Check for mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            if (player.isMyTurn && currentDraggableObject) {
                isDragging = false;

                RaycastHit2D hit;

                hit = Physics2D.Raycast(new Vector2(currentDraggableEntity.transform.position.x, currentDraggableEntity.transform.position.y), Vector2.zero, Mathf.Infinity);

                if (hit.collider != null)
                {   
                    GridItem tile = hit.transform.GetComponent<GridItem>();
                    if (tile)
                    {
                        currentDraggableEntity.SetOwner(player);
                        currentDraggableEntity.MoveTo(tile.GetX(), tile.GetY());
                        currentDraggableEntity.Init();
                        currentDraggableEntity.GetComponent<Collider2D>().enabled = true;
                    }
                }

                currentDraggableObject = null;
                currentDraggableEntity = null;
            }
        }
    }

    void SpawnNewDraggableObject()
    {
        // Instantiate a new draggable object at the mouse position
        Vector3 spawnPosition = GetMouseWorldPosition();
        spawnPosition.z = -2;
        currentDraggableObject = Instantiate(draggableObjectPrefab, spawnPosition, Quaternion.identity);
        currentDraggableEntity = currentDraggableObject.GetComponent<EntityUnit>();
        currentDraggableEntity.SetGridManager(gridManager);

        isDragging = true;
        offset = currentDraggableObject.transform.position - GetMouseWorldPosition();
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
   


}