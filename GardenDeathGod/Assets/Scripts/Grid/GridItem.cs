using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridItem : Entity
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

    [Header("Components")]
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite grass;
    [SerializeField]
    private Sprite deadGrass;

    public void init(int x, int y)
    {
        this.x = x;
        this.y = y;
        gridType = GridType.DEADGRASS;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

    public void Claim(Entity e)
    {
        owner = e;
        if (e.GetEntityType() == EntityType.PLAYER) gridType = GridType.GRASS;
        UpdateGridItem();
    }

    private void UpdateGridItem()
    {
        Sprite s = deadGrass;

        switch (gridType)
        {
            case GridType.GRASS:
                s = grass;
                break;
        }

        spriteRenderer.sprite = s;
    }

    public Entity GetOwner()
    {
        return owner;
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
