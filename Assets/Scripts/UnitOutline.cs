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

    private void OnMouseEnter()
    {
        DrawOutline();
    }

    private void OnMouseExit()
    {
        EraseOutline();
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
