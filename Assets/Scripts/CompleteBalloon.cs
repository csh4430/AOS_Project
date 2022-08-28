using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteBalloon : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(Define.MainCam.transform);
    }
    
    public void TurnBalloon(bool value)
    {
        gameObject.SetActive(value);
    }
}
