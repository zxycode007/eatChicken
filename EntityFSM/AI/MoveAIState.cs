using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveAIState : IAIState
{

    private const float MIN_MOVE_DIST = 1.5f;

    protected bool m_bOnMove = false;
    protected Vector3 m_attackPosition = Vector3.zero;

    public MoveAIState()
    {

    }

    public override void SetAttackPosition(Vector3 position)
    {
        m_attackPosition = position;
    }

    public override void Update(List<IEntity> targets)
    {
        if(targets == null || targets.Count == 0)
        {
            m_controller.SwitchEntityAIState(new IdleAIState());
            return;
        }

        if(m_bOnMove)
        {
            float dist = Vector3.Distance(m_controller.GetPosition(), m_attackPosition);

            if(dist < MIN_MOVE_DIST)
            {
                m_controller.SwitchEntityAIState(new IdleAIState());
                return;    
            }
            
        }

        //向目标移动
        m_bOnMove = true;
        m_controller.MoveTo(m_attackPosition);
    }

    
}
