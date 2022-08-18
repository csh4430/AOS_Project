using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
    private NavMeshAgent m_agent;
    public Action OnMoveEvent = null;
    public Action DeMoveEvent = null;

    private Vector3 m_targetPos = Vector3.zero;
    
    [SerializeField]
    private bool m_isTracing = false;

    private bool m_isMove = false;

    private float m_stopRange = 0;

    private UnitManager m_unit = null;
    private UnitAttack m_attack;
    private UnitManager m_targetUnit = null;

    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_unit = GetComponent<UnitManager>();
        TryGetComponent<UnitAttack>(out m_attack);
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, m_targetPos) <= m_stopRange)
        {
            m_targetPos = transform.position;
            Stop();
            if (m_isTracing)
            {
                m_isTracing = false;
                m_attack?.Attack(m_targetUnit, m_unit.Stat.DefDam);
            }
        }
    }

    public void Move(Vector3 targetPos, float stopRange = 0.1f)
    {
        m_stopRange = stopRange;
        if (Vector3.Distance(transform.position, targetPos) <= 1f)
            return;
        m_targetPos = targetPos;
        m_targetPos.y = transform.position.y;
        m_agent.isStopped = false;
        m_agent.SetDestination(targetPos);
        OnMoveEvent?.Invoke();
    }

    public void Move(UnitManager unit, float stopRange)
    {
        m_targetUnit = unit;
        m_isTracing = true;

        Move(unit.transform.position, stopRange);
    }

    public void Stop()
    {
        m_agent.isStopped = true;
        DeMoveEvent?.Invoke();
    }
}
