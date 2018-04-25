using UnityEngine;
using System.Collections;

public class IEntityAttr
{
    protected float m_maxHp = 0;
    protected float m_curHp = 0;
    protected float m_speed = 0;
    protected string m_attrName;

    protected IEntityAttrStrategy m_attrStrategy = null;

    //实体属性策略
    public IEntityAttrStrategy AttrStrategy
    {
        get
        {
            return m_attrStrategy;
        }
        set
        {
            m_attrStrategy = value;
        }
    }
    //属性状态恢复
    private void Reset()
    {
        m_curHp = m_maxHp;
    }

    public void InitAttribute()
    {
        m_attrStrategy.InitAttr(this);
        Reset();
    }

    //计算攻击力
    public int CalcAttackVal()
    {
        return m_attrStrategy.GetAttackVal(this);
    }

    //计算伤害减免
    public int CalcDmgReduceVal(IEntity attcker)
    {
        //获取敌人攻击力
        int attckVal = attcker.GetAttackValue();
        //伤害减免力
        int dmgVal = m_attrStrategy.GetDmgReduceVal(this);

        m_curHp -= attckVal - dmgVal;
        return dmgVal;
    }

    public string AttrName
    {
        get { return m_attrName; }
        set { m_attrName = value; }
    }


    public float MaxHP
    {
        get { return m_maxHp; }
        set { m_maxHp = value; }
    }

    public float CurHp
    {
        get { return m_curHp; }
        set { m_curHp = value; }
    }

    public float Speed
    {
        get { return m_speed; }
        set { m_speed = value; }
    }
     
}
