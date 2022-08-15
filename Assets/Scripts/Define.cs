using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    private static float m_camSpeed = 10f;
    public static float CamSpeed { get { return m_camSpeed; } }
    public static Camera MainCam
    {
        get
        {
            if (_mainCam == null)
            {
                _mainCam = Camera.main;
            }
            return _mainCam;
        }

    }

    private static Camera _mainCam;

    public static Vector2 MousePos => MainCam.ScreenToWorldPoint(Input.mousePosition);

    public static List<UnitManager> SELECTED_UNITS = new List<UnitManager>();
}
