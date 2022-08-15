using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsMove : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Vector3 point = Vector3.zero;
            int cnt = 0;
            Physics.Raycast(Define.MainCam.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, LayerMask.NameToLayer("Terrain"));       
            foreach(var unit in Define.SELECTED_UNITS)
            {
                point += unit.transform.position;
                cnt++;
            }
            point /= cnt;
            foreach (var unit in Define.SELECTED_UNITS)
            {
                unit.GetComponent<UnitMove>().Move(unit.transform.position - point + hit.point);
            }
        }
    }
}
