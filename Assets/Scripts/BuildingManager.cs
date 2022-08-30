using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : UnitManager
{
    protected List<UnitManager> m_unitsOnBuilding = new List<UnitManager>();

    private bool m_isSkillActive = false;
    private bool m_isSkillDeActive = true;

    protected virtual void Awake()
    {
        m_isBuilding = true;
    }
    protected override bool IsActive()
    {
        return true;
    }

    public virtual void Update()
    {
        if(m_unitsOnBuilding.Count > 0)
        {
            if(!m_isSkillActive)
                EnterSkillActive();
            StaySkillActive();
        }
        else
        {
            if(!m_isSkillDeActive)
                ExitSkillActive();
        }
    }

    public virtual void EnterSkillActive()
    {
        Debug.Log(1);
        m_isSkillActive = true;
        m_isSkillDeActive = false;
    }

    public virtual void StaySkillActive()
    {

    }
    public virtual void ExitSkillActive()
    {
        m_isSkillActive = false;
        m_isSkillDeActive = true;
        Debug.Log(0);
    }

    public void AddUnit(List<UnitManager> units)
    {
        foreach(UnitManager unit in units)
        {
            if (m_unitsOnBuilding.Contains(unit))
                continue;
            m_unitsOnBuilding.Add(unit);
        }
    }

    public void AddUnit(UnitManager unit)
    {
        if (m_unitsOnBuilding.Contains(unit))
            return;
        m_unitsOnBuilding.Add(unit);
    }

    public void RemoveUnit(UnitManager unit)
    {
        if(m_unitsOnBuilding.Contains(unit))
            m_unitsOnBuilding.Remove(unit);
    }
}
