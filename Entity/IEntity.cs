using UnityEngine;
using UnityEngine.AI;
using System.Collections;


/// <summary>
/// 实体接口
/// 实体的行为
/// </summary>
public abstract class IEntity
{
    protected GameObject m_gameObj;
    protected NavMeshAgent m_navAgent;
    protected AudioSource m_audio;
    protected string m_name;


    public string name
    {
        get { return m_name; }
    }
    //武器接口
    private IWeapon m_weapon;
    //实体属性接口
    private IEntityAttr m_attribute = null;

    public void SetEntityAttribute(IEntityAttr attr)
    {
        m_attribute = attr;
        m_attribute.InitAttribute();
        m_name = m_attribute.AttrName;

        m_navAgent.speed = m_attribute.Speed;
    }

    protected bool m_bKilled = false;
    protected float m_removeTime = 5.0f;
    protected bool m_canBeRemove = true;
    

    public IEntity()
    {

    }

    public void BindGameObject(GameObject go)
    {
        m_gameObj = go;
    }

    public GameObject GetGameObject()
    {
        return m_gameObj;
    }

    public void Release()
    {

    }

    /// <summary>
    /// 获取攻击力
    /// </summary>
    /// <returns></returns>
    public int GetAttackValue()
    {
        return m_attribute.CalcAttackVal();
    }

    public void Attack(IEntity target)
    {
        //设置武器攻击值
        m_weapon.attackValue = m_attribute.CalcAttackVal();

        //攻击目标
        m_weapon.Fire(target);
    }

    public void UnderAttack(IEntity attacker)
    {
        m_attribute.CalcDmgReduceVal(attacker);

        if(m_attribute.CurHp <= 0)
        {
            //死亡
            //Dead
        }

    }


}
