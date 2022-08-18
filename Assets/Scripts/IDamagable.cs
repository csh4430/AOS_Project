using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public UnitStat Stat { get; }
    public void Damage(int amount);
    public void Die();
}
