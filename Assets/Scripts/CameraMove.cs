using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public static void Tranlsate(Vector3 dir, float speed)
    {
        Vector3 m_pos = Define.MainCam.transform.position;
        m_pos += dir * speed * Time.deltaTime;
        m_pos.x = Mathf.Clamp(m_pos.x, Mathf.Tan(45.7f * Mathf.Deg2Rad)* Define.CamDistance - 2, Define.MapSize.x - Mathf.Tan(45.7f * Mathf.Deg2Rad) * Define.CamDistance);
        m_pos.z = Mathf.Clamp(m_pos.z, Mathf.Tan(30 * Mathf.Deg2Rad) * Define.CamDistance - 12, Define.MapSize.z - Mathf.Tan(30 * Mathf.Deg2Rad) * Define.CamDistance - 12);
        Define.MainCam.transform.position = m_pos;
    }
}
