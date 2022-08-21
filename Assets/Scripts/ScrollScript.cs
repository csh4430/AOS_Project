using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    private float m_cameraDistance = 15;
    [SerializeField]
    private float m_scrollSpeed = 2f;

    public float CameraDistance
    {
        get { return m_cameraDistance; }
        set
        {
            m_cameraDistance = Mathf.Clamp(value, 4, 15);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel");
        if (distance != 0)
        {
            CameraDistance += distance * m_scrollSpeed;
            Vector3 camPos = Define.MainCam.transform.position;
            camPos.y = CameraDistance;
            Define.MainCam.transform.position = camPos;
        }
    }
}
