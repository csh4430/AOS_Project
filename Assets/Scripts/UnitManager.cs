using System;
using System.Collections;
using System.Collections.Generic;
using ToolBox.Pools;
using UnityEngine;

public class UnitManager : MonoBehaviour, IDamagable
{
    [SerializeField]
    private UnitStat m_stat = null;

    public UnitStat Stat { get => m_stat;}

    protected bool m_isBuilding = false;

    [SerializeField]
    private bool m_isEnemy = false;

    [SerializeField]
    private bool m_isDead = false;

    public bool IsBuilding { get { return m_isBuilding; } }
    public bool IsEnemy { get { return m_isEnemy; } }

    public bool IsDead { get { return m_isDead; } }


    public Action OnCancelEvent = null;
    public Action OnDamageEvent { get; set; }
    public Action OnDieEvent { get; set; }

    public GameObject selectionCircle;

    private BuildingManager m_buildingOnUnit = null;

    private void Awake()
    {
        OnCancelEvent += () =>
        {
            m_buildingOnUnit?.RemoveUnit(this);
        };
            
    }

    protected virtual void OnMouseDown()
    {
        if (IsActive())
            Select(
                true,
                Input.GetKey(KeyCode.LeftShift) ||
                Input.GetKey(KeyCode.RightShift)
            );
    }

    private void _SelectUtil()
    {
        if (Define.SELECTED_UNITS.Contains(this)) return;
        Define.SELECTED_UNITS.Add(this);
        selectionCircle.SetActive(true);
    }

    public void Select() { Select(false, false); }
    public void Select(bool singleClick, bool holdingShift)
    {
        // basic case: using the selection box
        if (!singleClick)
        {
            _SelectUtil();
            return;
        }

        // single click: check for shift key
        if (!holdingShift)
        {
            List<UnitManager> selectedUnits = new List<UnitManager>(Define.SELECTED_UNITS);
            foreach (UnitManager um in selectedUnits)
                um.Deselect();
            _SelectUtil();
        }
        else
        {
            if (!Define.SELECTED_UNITS.Contains(this))
                _SelectUtil();
            else
                Deselect();
        }
    }

    public void WorkOnBuilding(BuildingManager building)
    {
        m_buildingOnUnit = building;
    }
    protected virtual bool IsActive()
    {
        return true;
    }

    public void Deselect()
    {
        if (!Define.SELECTED_UNITS.Contains(this)) return;
        Define.SELECTED_UNITS.Remove(this);
        selectionCircle.SetActive(false);
    }

    public void Damage(int amount)
    {
        OnDamageEvent?.Invoke();
        if (Stat.HP - amount <= 0)
        {
            Stat.ChangeStat(global::Stat.HP, 0);
            Die();
            return;
        }
        Stat.ChangeStat(global::Stat.HP, Stat.HP - amount);
    }

    public void Die()
    {
        m_isDead = true;
        Deselect();
        GetComponent<Collider>().enabled = false;
        gameObject.tag = "Die";
        OnDieEvent?.Invoke();
    }

    public void Destroy()
    {
        gameObject.Release();
    }
}
