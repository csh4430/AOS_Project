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
    public static UnitManager POINTED_UNIT = null;

    private static UnitsInput main_input = null;
    public static UnitsInput MAIN_INPUT
    {
        get
        {
            if(main_input == null)
                main_input = GameObject.Find("MainInput").GetComponent<UnitsInput>();
            return main_input;
        }
    }

    private static PlayerManager player_manager = null;

    public static PlayerManager PM
    {
        get
        {
            if(player_manager == null)
                player_manager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            return player_manager;
        }
    }

    private static GameManager game_manager = null;

    public static GameManager GM
    {
        get
        {
            if (game_manager == null)
                game_manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            return game_manager;
        }
    }

    public static Vector3 MapSize = new Vector3(100, 0, 100);

    public static float CamDistance = 15;
}
