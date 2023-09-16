using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private EntityType type;
    [SerializeField]
    protected Entity owner;
    public enum EntityType { PLAYER, ENEMY };

    public EntityType GetEntityType()
    {
        return type;
    }
    public Entity GetOwner()
    {
        return owner;
    }

    public void SetOwner(Entity owner)
    {
        this.owner = owner;
    }
}