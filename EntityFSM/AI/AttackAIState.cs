using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackAIState : IAIState
{
    protected IEntity m_attackTarget = null;

    public IEntity attackTarget
    {
        get { return m_attackTarget; }
        set { m_attackTarget = value; }
    }


    public AttackAIState(IEntity target)
    {
        m_attackTarget = target;
    }

    public override void SetAttackPosition(Vector3 position)
    {
        base.SetAttackPosition(position);
    }

    public override void Update(List<IEntity> targets)
    {
        if(m_attackTarget == null || m_attackTarget.IsDead() || targets == null || targets.Count == 0)
        {
            //失去目标，切到Idle状态
            m_controller.SwitchEntityAIState(new IdleAIState());
            return;
        }else
        {
            if(m_controller.TargetInAttackRange(m_attackTarget) == false)
            {
                //切换追击状态
                m_controller.SwitchEntityAIState(new ChaseAIState(m_attackTarget));
            }
            else
            {
                //直接攻击
                m_controller.Attack(m_attackTarget);

            }
        }
    }

    public override void RemoveTarget(IEntity target)
    {
        base.RemoveTarget(target);
        if(target.name == m_attackTarget.name)
        {
            m_attackTarget = null;
        }
    }

    
     
}
