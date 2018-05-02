using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NotPlayerEntityAIController : IEntityAIController
{
    private Vector3 m_attackPosition = Vector3.zero;

    public NotPlayerEntityAIController(IEntity entity):base(entity)
    {
        SwitchEntityAIState(new IdleAIState());
    }

    public NotPlayerEntityAIController(IEntity entity, Vector3 attackPosition)
        : base(entity)
    {
        m_attackPosition = attackPosition;
        SwitchEntityAIState(new IdleAIState());
    }


    public override void SwitchEntityAIState(IAIState state)
    {
        base.SwitchEntityAIState(state);

        state.SetAttackPosition(m_attackPosition);
    }
}
