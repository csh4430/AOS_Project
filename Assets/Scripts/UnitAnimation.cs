using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Animator m_animator = null;

    private int m_hash_Idle = Animator.StringToHash("Idle");
    private int m_hash_Move = Animator.StringToHash("Move");
    private int m_hash_Attack = Animator.StringToHash("Attack");
    private int m_hash_Damage = Animator.StringToHash("Damage");
    private int m_hash_Die = Animator.StringToHash("Die");

    private UnitManager m_unit = null;
    private UnitMove m_move;
    private UnitAttack m_attack;

    private void Awake()
    {
        m_unit = GetComponent<UnitManager>();
        m_animator = GetComponent<Animator>();
        m_move = GetComponent<UnitMove>();
        m_attack = GetComponent<UnitAttack>();
        m_move.OnMoveEvent += PlayMoveAnimation;
        m_move.DeMoveEvent += StopMoveAnimation;
        m_attack.OnAttackEvent += PlayAttackAnimation;
        m_unit.OnDamageEvent += PlayDamageAnimation;
        m_unit.OnDieEvent += PlayDieAnimation;
        if (m_unit.IsEnemy == false)
            Define.MAIN_INPUT.OnCancelEvent += CancelAllAnimation;
    }

    public void PlayDieAnimation()
    {
        m_animator.Play(m_hash_Die);
    }

    public void PlayMoveAnimation()
    {
        m_animator.SetBool(m_hash_Move, true);
    }

    public void StopMoveAnimation()
    {
        m_animator.SetBool(m_hash_Move, false);
    }
    public void PlayAttackAnimation()
    {
        m_animator.SetTrigger(m_hash_Attack);
    }

    public void PlayDamageAnimation()
    {
        m_animator.Play(m_hash_Damage);
    }
    public void CancelAllAnimation()
    {
        m_animator.Play(m_hash_Idle);
    }
}
