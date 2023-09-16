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

    [Header("Stats")]
    private GameObject[,] gridInfo;
    private GridItem[,] gridItems;

    // Start is called before the first frame update
    void Awake()
    {
        gridInfo = new GameObject[gridX, gridY];
        gridItems = new GridItem[gridX, gridY];
        
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

        transform.position = transform.position + gridOffset;
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
}
