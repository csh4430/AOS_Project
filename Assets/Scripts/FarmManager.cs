using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : BuildingManager
{

    private float m_makingTime = 0f;
    private int m_food = 0;
    private float m_goalTime = 20f;
    private CompleteBalloon m_completeBalloon;

    protected override void Awake()
    {
        base.Awake();
        m_completeBalloon = transform.Find("Balloon").GetComponent<CompleteBalloon>();
        m_completeBalloon.TurnBalloon(false);
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        if(m_food > 0)
        {
            Define.PM.Resource.Food += m_food;
            Define.GM.ShowFoodCount();
            m_food = 0;
            m_completeBalloon.TurnBalloon(false);
        }
    }

    public override void EnterSkillActive()
    {
        base.EnterSkillActive();
        m_makingTime = 0;
    }

    public override void StaySkillActive()
    {
        base.StaySkillActive();
        if (m_makingTime > m_goalTime / m_unitsOnBuilding.Count){
            m_food++;
            m_completeBalloon.TurnBalloon(true);
            m_makingTime = 0f;
        }
        m_makingTime += Time.deltaTime;
    }

    public override void ExitSkillActive()
    {
        base.ExitSkillActive();
        m_makingTime = 0f;
    }
}
