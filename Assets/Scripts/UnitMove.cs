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

    private bool m_isMove = false;
    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, m_targetPos) <= 0.1f)
        {
            m_targetPos = transform.position;
            Stop();
        }
    }

    public void Move(Vector3 targetPos)
    {
        if (Vector3.Distance(transform.position, targetPos) <= 1f)
            return;
        m_targetPos = targetPos;
        m_targetPos.y = transform.position.y;
        m_agent.isStopped = false;
        m_agent.SetDestination(targetPos);
        OnMoveEvent?.Invoke();
    }

    public void Stop()
    {
        m_agent.isStopped = true;
        DeMoveEvent?.Invoke();
    }
}
