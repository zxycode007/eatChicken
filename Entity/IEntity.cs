using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;


public enum EntityState
{
    EntityState_IsDead
}

public enum EntityType
{
    EntityType_PlayerRifeMan,
    EntityType_PlayerMaskMan,
    EntityType_NotPlayerZombie,
    EntityType_NotPlayerGaint,
    EntityType_NotPlayerSkeleton
}

/// <summary>
/// 实体接口
/// 实体的行为
/// </summary>
public abstract class IEntity
{
    protected GameObject m_modelObj;
    protected NavMeshAgent m_navAgent;
    protected AudioSource m_audio;
    protected string m_name;
    protected long m_entityId = -1;
    //属性ID
    protected long m_attrID = 0;
    protected IEntityAIController m_aiController;
    protected EntityType m_type = EntityType.EntityType_PlayerRifeMan;

    public EntityType entityType
    {
        get { return m_type; }
        set { m_type = value; }
    }


    public string name
    {
        get { return m_name; }
    }

    public long EntityID
    {
        get
        {
            return m_entityId;
        }
    }

    public long AttrID
    {
        get { return m_attrID; }
        set { m_attrID = value; }
    }

    public IEntityAIController aiController
    {
        get
        {
            return m_aiController;
        }
        set
        {
            m_aiController = value;
        }
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

    public IWeapon weapon
    {
        get { return m_weapon; }
        set { m_weapon = value; }
    }

    protected bool m_bKilled = false;
    protected float m_removeTime = 5.0f;
    protected bool m_canBeRemove = true;
    

    public IEntity()
    {
        m_entityId = EntityManager.GenerateEnityID();
    }

    public void BindModelObject(GameObject go)
    {
        m_modelObj = go;
    }

    public GameObject GetModelObject()
    {
        return m_modelObj;
    }

    public virtual void Update()
    {

    }


    public void Release()
    {

    }

    public virtual void UpdateBehavior(List<IEntity> targets)
    {
        m_aiController.Update(targets);
    }

    public void RemoveAITarget(IEntity target)
    {
        m_aiController.RemoveAITarget(target);
    }

    /// <summary>
    /// 获取攻击力
    /// </summary>
    /// <returns></returns>
    public int GetAttackValue()
    {
        return m_attribute.CalcAttackVal();
    }

    public float GetAttackRange()
    {
        return 0;
    }

    public Vector3 GetPosition()
    {
        return m_modelObj.transform.position;
    }

    public virtual void Attack(IEntity target)
    {
        //设置武器攻击值
        m_weapon.attackValue = m_attribute.CalcAttackVal();

        //攻击目标
        m_weapon.Fire(target);
    }

    public virtual void UnderAttack(IEntity attacker)
    {
        m_attribute.CalcDmgReduceVal(attacker);

        if(m_attribute.CurHp <= 0)
        {
            //死亡
            DoPlayDeadSound();
            DoPlayDeadEffect();
            Dead();
        }

    }

    public virtual void Dead()
    {


    }

    public virtual bool IsDead()
    {
        return m_bKilled;
    }

    public virtual void MoveTo(Vector3 pos)
    {

    }

    public virtual void StopMove()
    {

    }

    public abstract void DoPlayDeadSound();

    public abstract void DoPlayDeadEffect();

}
