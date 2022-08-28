using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnvironment : MonoBehaviour
{
    public Transform LightTransform = null;

    private void Update()
    {
        LightTransform.Rotate(Vector3.up, 10 * Time.deltaTime);
    }
}
