using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ToolBox.Pools;

public class ClickAnimation : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> m_renderers = new List<Renderer>();

    private Animator m_animator;
    private Sequence m_seq = null;
    private void Awake()
    {
        m_animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        m_seq = DOTween.Sequence();
        m_animator.Play("Start");
        m_renderers.ForEach((renderer) => renderer.material.color = new Color(0f, 0.8f, 2, 1f));
        m_renderers.ForEach((renderer) => m_seq.Join(renderer.material.DOColor(new Color(0f, 0.8f, 2, 0f), 1f).SetEase(Ease.OutExpo)));
        m_seq.AppendCallback(() => gameObject.Release());
    }
    private void OnDisable()
    {
        m_seq.Kill();
    }
}
