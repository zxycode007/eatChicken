using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 非玩家可控制实体
/// </summary>
public class NotPlayerEntity : IEntity {

    public NotPlayerEntity():base()
    {
        m_type = EntityType.EntityType_NotPlayerZombie;
    }

    public override void DoPlayDeadEffect()
    {
        
    }

    public override void DoPlayDeadSound()
    {
        
    }

    public override void Update()
    {
        base.Update();
    }
}
