using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : EntityUnit
{
    public void Handle(EntityUnit unit)
    {
        switch (unit.GetUnitType())
        {
            case UnitType.GRAVESTONE:
                
                break;
        }
    }
}
