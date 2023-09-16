using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItem : MonoBehaviour
{
    [Header("Info")]
    [SerializeField]
    private int x;
    [SerializeField]
    private int y;
    [SerializeField]
    private Entity owner;

    enum GridType { GRASS, DEADGRASS };
    [Header("Settings")]
    [SerializeField]
    private GridType gridType;

    public void init(int x, int y)
    {
        this.x = x;
        this.y = y;
        gridType = GridType.DEADGRASS;
    }

    public void claim(Entity e)
    {
        owner = e;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
