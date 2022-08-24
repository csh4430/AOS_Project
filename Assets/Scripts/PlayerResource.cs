using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerResource
{
    [SerializeField]
    private int m_exp;
    [SerializeField]
    private int m_gold;
    [SerializeField]
    private int m_food;
    
    public int Exp { get => m_exp; set => m_exp = value; }
    public int Gold { get => m_gold; set => m_gold = value; }
    public int Food { get => m_food; set => m_food = value; }
}
