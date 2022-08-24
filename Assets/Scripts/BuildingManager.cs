using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : UnitManager
{
    private void Awake()
    {
        m_isBuliding = true;
    }
    protected override bool IsActive()
    {
        return true;
    }
}
