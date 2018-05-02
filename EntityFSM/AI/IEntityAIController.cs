using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class IEntityAIController
{

    protected IEntity m_entity;

    protected float m_attackRange = 0;
    protected IAIState m_aiState = null;

    protected const float ATTACK_COOLDOWN = 1.0f;
    protected float m_coolDown = ATTACK_COOLDOWN;

    public float attackRange
    {
        get { return m_attackRange; }
        set { m_attackRange = value; }
    }

    public IEntityAIController(IEntity entity)
    {
        m_entity = entity;
        m_attackRange = m_entity.GetAttackRange();
    }

    //切换AI状态
    public virtual void SwitchEntityAIState(IAIState state)
    {
        m_aiState = state;
        m_aiState.AIController = this;
    }

    public bool TargetInAttackRange(IEntity target)
    {
        float dist = Vector3.Distance(m_entity.GetPosition(), target.GetPosition());
        if(dist < m_attackRange)
        {
            return true;
        }else
        {
            return false;
        }
    }

    /// <summary>
    /// 攻击目标
    /// </summary>
    /// <param name="target"></param>
    public virtual void Attack(IEntity target)
    {
        m_coolDown -= GlobalClient.Instance.timeManager.GetElapseTime();
        if (m_coolDown > 0)
            return;
        //重置冷却时间
        m_coolDown = ATTACK_COOLDOWN;
        //攻击目标
        m_entity.Attack(target);
    }

    public Vector3 GetPosition()
    {
        return m_entity.GetPosition();
    }


    public void MoveTo(Vector3 position)
    {
        m_entity.MoveTo(position);
    }

    public void StopMove()
    {
        m_entity.StopMove();
    }

    public void Dead()
    {
        m_entity.Dead();
    }

    public bool IsDead()
    {
        return m_entity.IsDead();
    }

    public void RemoveAITarget(IEntity target)
    {
        m_aiState.RemoveTarget(target);
    }

    public void Update(List<IEntity> targets)
    {
        m_aiState.Update(targets);
    }
     
}
