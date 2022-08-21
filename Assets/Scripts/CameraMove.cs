using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public static void Tranlsate(Vector3 dir, float speed)
    {
        Vector3 m_pos = Define.MainCam.transform.position;
        m_pos += dir * speed * Time.deltaTime;
        m_pos.x = Mathf.Clamp(m_pos.x, Mathf.Tan(45.7f * Mathf.Deg2Rad)* 15 - 2, Define.MapSize.x - Mathf.Tan(45.7f * Mathf.Deg2Rad) * 15);
        m_pos.z = Mathf.Clamp(m_pos.z, Mathf.Tan(30 * Mathf.Deg2Rad) * 15 - 6, Define.MapSize.z - Mathf.Tan(30 * Mathf.Deg2Rad) * 15 - 8);
        Define.MainCam.transform.position = m_pos;
    }
}
