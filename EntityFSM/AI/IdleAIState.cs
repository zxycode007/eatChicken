using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IdleAIState : IAIState
{
    bool m_bSetAttackPosition = false;

    protected Vector3   m_attackPosition = Vector3.zero;
    protected float m_maxSearchDist = 100;

    public float MaxSearchDist
    {
        get { return m_maxSearchDist; }
        set { m_maxSearchDist = value; }
    }

    public IdleAIState()
    {

    }

    public override void SetAttackPosition(Vector3 position)
    {
        m_bSetAttackPosition = true;
        m_attackPosition = position;
    }


    public override void Update(List<IEntity> targets)
    {
        //没有目标
        if(targets == null || targets.Count == 0)
        {
            //朝进攻位置移动
            if(m_bSetAttackPosition)
            {
                m_controller.SwitchEntityAIState(new MoveAIState());
            }else
            {
                m_controller.SwitchEntityAIState(new GuardAIState());
            }
            return;
        }
        Vector3 curPos = m_controller.GetPosition();
        //先找一个最近目标
        IEntity theNearTarget = null;

        float minDist = m_maxSearchDist;
        for(int i=0; i<targets.Count; i++)
        {
            if (targets[i].IsDead())
                continue;

            float dist = Vector3.Distance(curPos, targets[i].GetPosition());
            if(dist < minDist)
            {
                minDist = dist;
                theNearTarget = targets[i];
            }
        }

        //没有目标
        if(theNearTarget == null)
        {
            return;
        }else
        {
             if(m_controller.TargetInAttackRange(theNearTarget))
             {
                 //在攻击范围内，直接攻击
             }
             else
             {
                 //不在攻击范围内，先靠近

             }

        }

       
    }

    
   
}
