using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolBox.Pools;

public class UnitsInput : MonoBehaviour
{

    public GameObject ClickEffect = null;
    void Update()
    {
        UnitsMove();
    }

    public void UnitsMove()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach(var unit in Define.SELECTED_UNITS)
            {
                if (unit.IsBulding || unit.IsEnemy)
                    continue;
                unit.OnCancelEvent?.Invoke();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Physics.Raycast(Define.MainCam.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, LayerMask.NameToLayer("Terrain"));
            if(Define.POINTED_UNIT == null)
                ClickEffect.Reuse(hit.point + Vector3.up * 0.3f, Quaternion.identity);
        }
        if (Input.GetMouseButton(1))
        {
            
            RaycastHit hit;
            Vector3 point = Vector3.zero;
            int cnt = 0;
            Physics.Raycast(Define.MainCam.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, LayerMask.NameToLayer("Terrain"));
            foreach (var unit in Define.SELECTED_UNITS)
            {
                if (unit.IsEnemy)
                    continue;
                if (unit.IsBulding)
                    continue;
                point += unit.transform.position;
                cnt++;
            }
            point /= cnt;
            if (Define.POINTED_UNIT != null)
            {
                foreach (var unit in Define.SELECTED_UNITS)
                {
                    if (!unit.IsEnemy)
                    if (!unit.IsBulding)
                        unit.GetComponent<UnitMove>().Move(Define.POINTED_UNIT, unit.Stat.Range, Define.POINTED_UNIT.IsEnemy);
                }
            }
            else
            {
                foreach (var unit in Define.SELECTED_UNITS)
                {
                    if (!unit.IsEnemy)
                    if (!unit.IsBulding)
                        unit.GetComponent<UnitMove>().Move(unit.transform.position - point + hit.point);
                }
            }
        }
    }
}
