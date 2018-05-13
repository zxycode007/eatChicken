using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EntityFactory : IEntityFactory
{

    public override NotPlayerEntity CreateNotPlayerEntity(EntityType entityType, EWeaponType curWeapon, Vector3 spawnPoint)
    {
        NotPlayerEntity entity = null;
        string prefabName = "";
        switch (entityType)
        {
            case EntityType.EntityType_NotPlayerZombie:
                entity = new NotPlayerZombie();
                break;
            case EntityType.EntityType_NotPlayerSkeleton:

                break;
            case EntityType.EntityType_NotPlayerGaint:

                break;
            default:
                entity = new NotPlayerZombie();
                break;
        }
        
        return entity;
    }

    public override PlayerEntity CreatePlayerEntity(EntityType entityType, EWeaponType curWeapon, Vector3 spawnPoint)
    {
        PlayerEntity entity = null;
        GameObject tmpGo = null;
        string prefabName = "";
        switch (entityType)
        {
            case EntityType.EntityType_PlayerRifeMan:
                entity = new PlayerRifeMan();
                prefabName = "RifeMan";
                break;
            case EntityType.EntityType_PlayerMaskMan:
                entity = new PlayerMaskMan();
                prefabName = "MaskMan";
                break;
            default:
                entity = new PlayerRifeMan();
                prefabName = "RifeMan";
                break;
        }
        //先读取预设
        tmpGo = GlobalClient.Instance.objPoolManager.Get<PlayerEntity>();
        if (tmpGo == null)
            entity = tmpGo.GetComponent<PlayerEntity>();
        //設置模型
        
       //创建武器
        IWeapon weapon = CreateWeapon(curWeapon);
        entity.weapon = weapon;
        //创建属性
        PlayerEntityAttr attr = CreatePlayerEntityAttr(0);
        entity.SetEntityAttribute(attr);
        //创建ai行为
        PlayerEntityAIController aiController = CreatePlayerEntityAIController();
        entity.aiController = aiController;
        
        //添加到实体管理器
        GlobalClient.Instance.entityManager.AddPlayerdEntity(entity);
        return entity;
    }
    

    //临时方法
    private PlayerEntityAttr CreatePlayerEntityAttr(int id)
    {
        return null;
    }

    private IWeapon CreateWeapon(EWeaponType weapon)
    {
        return null;
    }

    private PlayerEntityAIController CreatePlayerEntityAIController()
    {
        return null;
    }
}
