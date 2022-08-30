using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private UIManager m_uiManager = null;

    private void Awake()
    {
        m_uiManager = GetComponent<UIManager>();
    }

    public void ShowFoodCount()
    {
        m_uiManager.ChangeFoodText(Define.PM.Resource.Food);
    }
}
