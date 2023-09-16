using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private EntityType type;
    public enum EntityType { PLAYER, ENEMY };
    
    public EntityType GetEntityType()
    {
        return type;
    }
}