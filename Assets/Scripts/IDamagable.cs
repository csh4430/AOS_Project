using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public UnitStat Stat { get; }
    public Action OnDamageEvent { get; set; }
    public Action OnDieEvent { get; set; }
    public void Damage(int amount);
    public void Die();
}
