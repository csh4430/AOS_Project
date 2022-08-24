using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolBox.Pools;

public class UnitMap : MonoBehaviour
{
    [SerializeField]
    private GameObject m_objectPrefab = null;

    [SerializeField]
    private Transform m_parent = null;

    private RectTransform m_rect = null;

    private float m_scale = 1f;

    private GameObject m_mapObject;

    private void OnEnable()
    {
         m_mapObject = m_objectPrefab.Reuse(m_parent);
        m_rect = m_mapObject.GetComponent<RectTransform>();
        m_scale = m_parent.GetComponent<RectTransform>().sizeDelta.x / 100f;
    }

    private void Update()
    {
        Vector2 target = new Vector2(transform.position.x, transform.position.z);
        m_rect.anchoredPosition = target * m_scale;
        Vector2 size = new Vector2(Mathf.Tan(45.7f * Mathf.Deg2Rad) * Define.CamDistance, Mathf.Tan(30 * Mathf.Deg2Rad) * Define.CamDistance);
        m_rect.sizeDelta = size * 10f;
    }
}
