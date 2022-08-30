using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayerResource m_resource = null;

    public PlayerResource Resource { get => m_resource; set => m_resource = value; }


}
