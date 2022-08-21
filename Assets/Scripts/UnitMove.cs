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

        m_unit.OnCancelEvent += () =>
        {
            m_isTracing = false;
            Stop();
        };

        m_targetPos = transform.position;
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, m_targetPos) <= m_stopRange)
        {
            m_targetPos = transform.position;
            Stop();
            if (m_isTracing)
            {
                if (m_targetUnit != null && !m_targetUnit.IsDead)
                    m_attack?.Attack(m_targetUnit, m_unit.Stat.DefDam);
                else
                    m_isTracing = false;
            }
        }
    }

    public void Move(Vector3 targetPos, float stopRange = 0.1f, bool isTracing = false)
    {

        m_stopRange = stopRange;
        if (Vector3.Distance(transform.position, targetPos) <= 1f)
            return;
        m_agent.obstacleAvoidanceType = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
        m_targetPos = targetPos;
        m_targetPos.y = transform.position.y;
        transform.LookAt(m_targetPos);
        if (Vector3.Distance(transform.position, m_targetPos) <= m_stopRange)
            return;

        m_isTracing = isTracing;
        m_agent.isStopped = false;
        m_agent.SetDestination(targetPos);
        OnMoveEvent?.Invoke();
    }

    public void Move(UnitManager unit, float stopRange, bool isTracing = true)
    {
        m_targetUnit = unit;
        Vector3 target = unit.GetComponent<Collider>().ClosestPoint(transform.position);
        m_isTracing = isTracing;
        if (!m_isTracing)
            stopRange = 1f;
        Move(target, stopRange, isTracing);
    }

    public void Stop()
    {
        m_agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
        m_agent.isStopped = true;
        DeMoveEvent?.Invoke();
    }
}
