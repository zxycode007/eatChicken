using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public abstract class IAIState
{
    protected IEntityAIController m_controller;


    /// <summary>
    /// 从目标列表中移除目标
    /// </summary>
    /// <param name="target"></param>
    public virtual void RemoveTarget(IEntity target)
    {

    }

    public virtual void SetAttackPosition(Vector3 position)
    {

    }

    public IEntityAIController AIController
    {
        get { return m_controller; }
        set { m_controller = value; }
    }

    

    public IAIState()
    {

    }

    public abstract void Update(List<IEntity> targets);
    

    
}
