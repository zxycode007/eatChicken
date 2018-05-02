using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChaseAIState : IAIState
{
    protected IEntity m_chaseTarget = null;

    private float MAX_CHASE_DIST = 100f;
    private float MIN_CHASE_DIST = 100f;

    private Vector3 m_chasePosition = Vector3.zero;
    private bool m_bOnChase = false;


    public ChaseAIState(IEntity targeat)
    {
        m_chaseTarget = targeat;
    }

    public override void RemoveTarget(IEntity target)
    {
        base.RemoveTarget(target);
        if(m_chaseTarget.name == target.name)
        {
            m_chaseTarget = null;
        }
    }

    public override void Update(List<IEntity> targets)
    {
        if(m_chaseTarget == null || m_chaseTarget.IsDead())
        {
            m_controller.SwitchEntityAIState(new IdleAIState());
            return;
        }

        if(m_controller.TargetInAttackRange(m_chaseTarget))
        {
            m_controller.StopMove();
            m_controller.SwitchEntityAIState(new AttackAIState(m_chaseTarget));
            return;
        }

        if(m_bOnChase)
        {
            //已经到达目标，但不见目标
            float dist = Vector3.Distance(m_chasePosition, m_controller.GetPosition());
            if(dist < MIN_CHASE_DIST)
            {
                m_controller.SwitchEntityAIState(new IdleAIState());
                return;
            }
        }

        m_bOnChase = true;
        m_chasePosition = m_chaseTarget.GetPosition();
        m_controller.MoveTo(m_chasePosition);
        
    }

    
}
