using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Animator m_animator = null;

    private int m_hash_Move = Animator.StringToHash("Move");

    private UnitMove m_move;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_move = GetComponent<UnitMove>();
        m_move.OnMoveEvent += PlayMoveAnimation;
        m_move.DeMoveEvent += StopyMoveAnimation;
    }

    public void PlayMoveAnimation()
    {
        m_animator.SetBool(m_hash_Move, true);
    }

    public void StopyMoveAnimation()
    {
        m_animator.SetBool(m_hash_Move, false);
    }
}
