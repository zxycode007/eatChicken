using UnityEngine;
using System.Collections;

/// <summary>
/// 可玩家控制实体属性
/// </summary>
public class PlayerEntityAttr : IEntityAttr
{

    public PlayerEntityAttr(int maxHp, float speed, string attrName)
    {
        m_attrName = attrName;
        m_maxHp = maxHp;
        m_speed = speed;
        m_curHp = m_maxHp;
    }
  
}
