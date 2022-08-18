using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitOutline : MonoBehaviour
{
    [SerializeField]
    private List<OutlineScript> m_outline_Parts = new List<OutlineScript>();

    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;

    private UnitManager _unit;

    private void Awake()
    {
        _unit = GetComponent<UnitManager>();
    }

    private void OnMouseEnter()
    {
        DrawOutline();
        Define.POINTED_UNIT = _unit;
    }

    private void OnMouseExit()
    {
        EraseOutline();
        Define.POINTED_UNIT = null;
    }

    public void DrawOutline()
    {
        m_outline_Parts.ForEach(part => part.CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor));
    }

    public void EraseOutline()
    {
        m_outline_Parts.ForEach(part => part.DestroyOutline());
    }
}
