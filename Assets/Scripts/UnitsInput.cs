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
                if (unit.IsBuilding || unit.IsEnemy)
                    continue;
                unit.OnCancelEvent?.Invoke();
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Physics.Raycast(Define.MainCam.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, LayerMask.GetMask("Terrain"));
            if(Define.POINTED_UNIT == null)
                ClickEffect.Reuse(hit.point + Vector3.up * 0.3f, Quaternion.identity);
            foreach(var unit in Define.SELECTED_UNITS)
            {
                if (Define.POINTED_UNIT != null)
                if(Define.POINTED_UNIT.IsBuilding)
                {
                    unit.WorkOnBuilding(Define.POINTED_UNIT as BuildingManager);
                }
                unit.OnCancelEvent?.Invoke();
            }
        }
        if (Input.GetMouseButton(1))
        {
            
            RaycastHit hit;
            Vector3 point = Vector3.zero;
            int cnt = 0;
            Physics.Raycast(Define.MainCam.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, LayerMask.GetMask("Terrain"));
            foreach (var unit in Define.SELECTED_UNITS)
            {
                if (unit.IsEnemy)
                    continue;
                if (unit.IsBuilding)
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
                    if (!unit.IsBuilding)
                        unit.GetComponent<UnitMove>().Move(Define.POINTED_UNIT, unit.Stat.Range, Define.POINTED_UNIT.IsEnemy);
                }
            }
            else
            {
                foreach (var unit in Define.SELECTED_UNITS)
                {
                    if (!unit.IsEnemy)
                    if (!unit.IsBuilding)
                        unit.GetComponent<UnitMove>().Move(unit.transform.position - point + hit.point);
                }
            }
        }
    }
}
