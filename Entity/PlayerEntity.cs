using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家可控制实体
/// </summary>
public class PlayerEntity : IEntity
{
    public PlayerEntity():base()
    {
        m_type = EntityType.EntityType_PlayerRifeMan;
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
