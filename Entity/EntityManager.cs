using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 实体管理器
/// 对Entity进行添加，更新，查询，删除等操作
/// </summary>
public class EntityManager : IGameSystem
{

    //玩家实体列表
    private List<IEntity> m_playerEntities;
    //非玩家实体列表
    private List<IEntity> m_notPlayerEntities;

    private static long m_idOrder = 0;

    public void AddPlayerdEntity(PlayerEntity entity)
    {
        m_playerEntities.Add(entity);
    }

    public void RemovePlayerEntity(PlayerEntity entity)
    {
        m_playerEntities.Remove(entity);
    }

    public void AddNotPlayerEntity(NotPlayerEntity entity)
    {
        m_notPlayerEntities.Add(entity);
    }

    public void RemoveNotPlayerEntity(NotPlayerEntity entity)
    {
        m_notPlayerEntities.Remove(entity);
    }

    public EntityManager()
    {
        m_notPlayerEntities = new List<IEntity>();
        m_playerEntities = new List<IEntity>();
    }

    public int PlayerEntityCount
    {
        get { return m_playerEntities.Count; }
    }

    public int NotPlayerEntityCount
    {
        get { return m_notPlayerEntities.Count; }
    }

    public int Count { get { return m_notPlayerEntities.Count + m_playerEntities.Count; } }

    /// <summary>
    /// 清理没用到的实体
    /// </summary>
    public void Clean()
    {
         
    }

    public PlayerEntity FindPlayerEntity(string name)
    {
        return null;
    }

    public NotPlayerEntity FindNotPlayerEntity(string name)
    {
        return null;
    }

    public static long GenerateEnityID()
    {
        m_idOrder++;
        return m_idOrder;
    }

    public void RemoveEntity(List<IEntity> entities, List<IEntity> opponents, EEntityState state)
    {
        List<IEntity> removeList = new List<IEntity>();
        foreach(IEntity entity in entities)
        {
            if(entity.IsDead())
            {
                removeList.Add(entity);
                //准备发送事件
                DataBuffer buf = new DataBuffer();
                buf.WriteLong(entity.EntityID);
                NotifyEvent(this, GameEventType.EVT_GAME_SWITCH, new GameEvtArg(buf));
            }
        }
        foreach (IEntity removeUnit in removeList)
        {
            foreach (IEntity opponent in opponents)
            {
                opponent.RemoveAITarget(removeUnit);
            }
            removeUnit.Release();
            entities.Remove(removeUnit);
        }
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    //实体更新
    public override void Update()
    {
        base.Update();
        foreach(PlayerEntity entity in m_playerEntities)
        {
            entity.Update();
        }
        foreach (NotPlayerEntity entity in m_notPlayerEntities)
        {
            entity.Update();
        }
        Clean();
    }

    //实体行为更新
    private void UpdateEntityBehavior(List<IEntity> entities, List<IEntity> targets)
    {
        foreach(IEntity entity in entities)
        {
            entity.UpdateBehavior(targets);
        }
    }

    public override void Release()
    {
        base.Release();
    }

    public IEntity GetCurEntity()
    {
        return null;
    }

}
