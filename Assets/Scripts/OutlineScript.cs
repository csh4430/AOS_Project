using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{
    
    private Renderer outlineRenderer;
    private bool m_isOn = false;
    GameObject outlineObject = null;
    public void CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {
        if (m_isOn)
            return;
        m_isOn = true;
        if (outlineObject == null)
            outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        else
        {
            outlineObject.SetActive(true);
        }
        outlineObject.transform.localScale = new Vector3(1, 1, -1);
        Renderer rend = outlineObject.GetComponent<Renderer>();

        rend.material = outlineMat;
        rend.material.SetColor("_OutlineColor", color);
        rend.material.SetFloat("_Scale", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        outlineObject.GetComponent<OutlineScript>().enabled = false;
    }

    public void DestroyOutline()
    {
        if (!m_isOn)
            return;
        m_isOn = false;
        outlineObject.gameObject.SetActive(false);
    }
}