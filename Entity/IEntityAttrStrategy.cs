using UnityEngine;
using System.Collections;

//实体属性策略接口
//实体属性值相关算法接口
public abstract class IEntityAttrStrategy
{
    public abstract void InitAttr(IEntityAttr entity);

    //获取攻击力
    public abstract int GetAttackVal(IEntityAttr entityAttr);

    //获取伤害减免值
    public abstract int GetDmgReduceVal(IEntityAttr entityAttr);
    
}
