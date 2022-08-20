using System.Collections;
using System.Collections.Generic;
using ToolBox.Pools;
using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    private ParticleSystem m_particle = null;

    private void Awake()
    {
        m_particle = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        m_particle.Play();
    }

    private void OnParticleSystemStopped()
    {
        gameObject.Release();
    }
}
