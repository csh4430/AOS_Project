using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsInput : MonoBehaviour
{
    private GameObject m_lastSelectedObject = null;
    void Update()
    {
        UnitsMove();
    }

    public void UnitsMove()
    {
        if (Input.GetMouseButton(1))
        {
            
            RaycastHit hit;
            Vector3 point = Vector3.zero;
            int cnt = 0;
            Physics.Raycast(Define.MainCam.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, LayerMask.NameToLayer("Terrain"));
            foreach (var unit in Define.SELECTED_UNITS)
            {
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
                    if (!unit.IsBulding)
                        unit.GetComponent<UnitMove>().Move(Define.POINTED_UNIT, unit.Stat.Range, Define.POINTED_UNIT.IsEnemy);
                }
            }
            else
            foreach (var unit in Define.SELECTED_UNITS)
            {
                if(!unit.IsBulding)
                    unit.GetComponent<UnitMove>().Move(unit.transform.position - point + hit.point);
            }
        }
    }
}
