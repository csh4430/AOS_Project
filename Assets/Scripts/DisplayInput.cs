using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Vector3 m_dir = Vector3.zero;
    private bool m_isOver = false;

    private void Update()
    {
        if(m_isOver)
            CameraMove.Tranlsate(m_dir.normalized, Define.CamSpeed);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_isOver = false;
    }
}
