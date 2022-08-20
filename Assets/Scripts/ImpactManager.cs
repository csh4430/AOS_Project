using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolBox.Pools;

public enum Particle
{
    Impact
}

public class ImpactManager : MonoBehaviour
{
    [SerializeField]
    private List<ImpactScript> m_impactList = new List<ImpactScript>();

    private UnitManager m_unit = null;

    private void Awake()
    {
        m_unit = GetComponent<UnitManager>();

        m_unit.OnDamageEvent += () => PlayParticle(Particle.Impact);
    }

    public void PlayParticle(Particle particle)
    {
        m_impactList[(int)particle].gameObject.Reuse(transform.position + Vector3.up * 0.3f, Quaternion.identity);
    }


}
