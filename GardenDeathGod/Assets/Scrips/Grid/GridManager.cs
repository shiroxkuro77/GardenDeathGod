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
    private GridItem[,] gridInfoScripts;

    // Start is called before the first frame update
    void Start()
    {
        gridInfo = new GameObject[gridX, gridY];

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Claim(Entity e, int x, int y)
    {
        if (!gridInfoScripts[x, y]) gridInfoScripts[x, y] = gridInfo[x, y].GetComponent<GridItem>();
        gridInfoScripts[x, y].claim(e);
    }

    public GameObject GetGridObjectAt(int x, int y)
    {
        return gridInfo[x, y];
    }
}
