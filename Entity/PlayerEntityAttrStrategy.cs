using UnityEngine;
using System.Collections;

public class PlayerEntityAttrStrategy : IEntityAttrStrategy
{

    public override void InitAttr(IEntityAttr entityAttr)
    {
        PlayerEntityAttr attri = entityAttr as PlayerEntityAttr;
        if (attri == null)
            return;

        
    }

    public override int GetAttackVal(IEntityAttr entityAttr)
    {
        return 10;
    }

    public override int GetDmgReduceVal(IEntityAttr entityAttr)
    {
        return 3;
    }
     
}
