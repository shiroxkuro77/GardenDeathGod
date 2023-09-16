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
    private int gridRows;
    [SerializeField]
    private int gridColumns;
    [SerializeField]
    private int gridSize;

    [Header("Stats")]
    private GameObject[,] gridInfo;
    private GridItem[,] gridInfoScripts;

    // Start is called before the first frame update
    void Start()
    {
        gridInfo = new GameObject[gridRows, gridColumns];

        for (int x = 0; x < gridRows; x++)
        {
            for (int y = 0; y < gridColumns; y++)
            {
                GameObject go = Instantiate(gridObject);
                go.transform.position = new Vector3(x * gridSize, y * gridSize, 0);

                GridItem gridItem = go.GetComponent<GridItem>();
                gridItem.init(x, y);

                gridInfo[x, y] = go;
            }
        }
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
