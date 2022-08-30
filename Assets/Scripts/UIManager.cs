using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text m_foodText = null;

    private void Awake()
    {
        m_foodText = GameObject.Find("FoodText").GetComponent<Text>();
    }

    public void ChangeFoodText(int value)
    {
        m_foodText.text = value.ToString();
    }
}
