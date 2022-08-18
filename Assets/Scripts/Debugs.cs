using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugs : MonoBehaviour
{
    [SerializeField]
    private List<UnitManager> SELECTED_UNITS = Define.SELECTED_UNITS;

    [SerializeField]
    private UnitManager POINTED_UNIT = Define.POINTED_UNIT;
}
