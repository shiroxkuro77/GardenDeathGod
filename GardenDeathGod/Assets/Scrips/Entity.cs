using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public void ClaimTile(GridManager gm, int x, int y)
    {
        gm.Claim(this, x, y);
    }
}