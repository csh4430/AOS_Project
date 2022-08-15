using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public static void Tranlsate(Vector3 dir, float speed)
    {
        Define.MainCam.transform.position += dir * speed * Time.deltaTime;
    }
}
