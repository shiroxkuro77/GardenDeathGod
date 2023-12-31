using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private GameObject gridObject;

    [Header("Settings")]
    [SerializeField]
    private int gridX;
    [SerializeField]
    private int gridY;
    [SerializeField]
    private int gridSize;
    [SerializeField]
    private Vector3 gridOffset;
    [SerializeField]
    private GameObject enemy;

    [Header("Stats")]
    private GameObject[,] gridInfo;
    private GridItem[,] gridItems;
    private EntityUnit[,] gridEntities;

    // Start is called before the first frame update
    void Awake()
    {
        gridInfo = new GameObject[gridX, gridY];
        gridItems = new GridItem[gridX, gridY];
        gridEntities = new EntityUnit[gridX, gridY];
        
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                GameObject go = Instantiate(gridObject);
                go.transform.parent = gameObject.transform;
                go.transform.position = new Vector3(x * gridSize, y * gridSize, 0);
                go.name = "[" + x + ", " + y + "]";

                GridItem gridItem = go.GetComponent<GridItem>();
                gridItem.init(x, y);

                gridInfo[x, y] = go;
            }
        }
        Enemy enemybehavior = enemy.GetComponent<Enemy>();
        enemybehavior.gridX = this.gridX;
        enemybehavior.gridY = this.gridY;
        enemybehavior.gridSize = this.gridSize;
        transform.position = transform.position + gridOffset;
        enemy.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    public void UpdatePosition(int x, int y, EntityUnit entity)
    {
        gridEntities[x, y] = entity;
    }

    public EntityUnit GetEntityAt(int x, int y)
    {
        if (!(x > 0 && y > 0 && x < gridX && y < gridY)) return null;
        return gridEntities[x, y];
    }

    public void ClaimTileAt(Entity e, int x, int y)
    {
        if (!gridItems[x, y]) gridItems[x, y] = gridInfo[x, y].GetComponent<GridItem>();
        gridItems[x, y].Claim(e);
    }

    public Vector3 GetPosOfGrid(int x, int y)
    {
        return gridInfo[x, y].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public int numberOfGrass()
     {
    
        int num = 0;

        //TO DO: Get number of Grass here

         for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                GameObject go = gridInfo[x,y];
                if (go == null) {
                    continue;
                }

                GridItem gridItem = go.GetComponent<GridItem>();
                if (gridItem.isGrass()) {
                    num += 1;
                }
            }
        }

        return num * 10;
    }
    public int numberOfDeadGrass()
     {
        
        int num = 0;

        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                GameObject go = gridInfo[x,y];
                if (go == null) {
                    continue;
                }

                GridItem gridItem = go.GetComponent<GridItem>();
                if (!gridItem.isGrass()) {
                    num += 1;
                }
            }
        }

        return num * 10;
    }
}
