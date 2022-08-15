using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMove : MonoBehaviour
{
    private NavMeshAgent m_agent;
    private void Awake()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }
    public void Move(Vector3 targetPos)
    {
        m_agent.SetDestination(targetPos);
    }
}
