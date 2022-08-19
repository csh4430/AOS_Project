using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    public Action OnAttackEvent = null;
    [SerializeField]
    private bool m_isAttack = false;
    private UnitManager m_unit = null;
    private UnitManager m_targetUnit = null;

    private int m_damage = 0;
    private void Awake()
    {
        m_unit = GetComponent<UnitManager>();
        if(m_unit.IsEnemy == false)
        {
            Define.MAIN_INPUT.OnCancelEvent += EndAttack;
        }
    }

    public void Attack(UnitManager unit, int amount)
    {
        if (m_isAttack)
            return;
        m_isAttack = true;
        transform.LookAt(unit.transform);
        m_targetUnit = unit;
        OnAttackEvent?.Invoke();
        m_damage = amount;

    }

    public void AttackInAnimation()
    {
        Vector3 target = m_targetUnit.GetComponent<Collider>().ClosestPoint(transform.position);
        if (Vector3.Distance(transform.position, target) > m_unit.Stat.Range)
        {
            EndAttack();
            return;
        }
        m_targetUnit.Damage(m_damage);
    }

    public void EndAttack()
    {
        m_isAttack = false;
    }
}
