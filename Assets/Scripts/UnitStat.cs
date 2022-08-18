using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    ORIGINAL_HP,
    HP,
    MP,
    DEFAULT_DAMAGE,
    SKILL_DAMAGE,
    DEFAULT_ARMOR,
    SKILL_ARMOR,
    RANGE,
    ATK_SPEED

}

[System.Serializable]
public class UnitStat
{
    private int m_originalHp;
    [SerializeField]
    private int m_hp;
    [SerializeField]
    private int m_mp;
    [SerializeField]
    private int m_defDam;
    [SerializeField]
    private int m_skillDam;
    [SerializeField]
    private int m_defArm;
    [SerializeField]
    private int m_skillArm;


    [SerializeField]
    private float m_atkSpeed;
    [SerializeField]
    private float m_range;

    public int Original_Hp { get => m_originalHp; }
    public int HP { get => m_hp; }
    public int MP { get => m_mp; }
    public int DefDam { get => m_defDam; }
    public int DefArm { get => m_defArm; }
    public int SkillDam { get => m_skillDam; }
    public int SkillArm { get => m_skillArm; }
    public float ATKSpeed { get => m_atkSpeed; }
    public float Range { get => m_range; }

    public void ChangeStat(Stat selectStat, int amount)
    {
        switch(selectStat)
        {
            case Stat.ORIGINAL_HP:
                m_originalHp = amount;
                break;

            case Stat.HP:
                m_hp = amount;
                break;

            case Stat.MP:
                m_mp = amount;
                break;

            case Stat.DEFAULT_DAMAGE:
                m_defDam = amount;
                break;

            case Stat.SKILL_DAMAGE:
                m_skillDam = amount;
                break;

            case Stat.SKILL_ARMOR:
                m_skillArm = amount;
                break;

            case Stat.DEFAULT_ARMOR:
                m_defArm = amount;
                break;
        }
    }

    public void ChangeStat(Stat selectStat, float amount)
    {
        switch(selectStat)
        {
            case Stat.RANGE:
                m_range = amount;
                break;

            case Stat.ATK_SPEED:
                m_atkSpeed = amount;
                break;
        }
    }

    public UnitStat()
    {
        m_originalHp = 0;
        m_hp = 0;
        m_mp = 0;
        m_defDam= 0;
        m_skillDam = 0;
        m_defArm = 0;
        m_skillArm = 0;

        m_atkSpeed = 0;
        m_range = 0;
    }
}
