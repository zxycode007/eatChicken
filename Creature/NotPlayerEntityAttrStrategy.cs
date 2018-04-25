using UnityEngine;
using System.Collections;

public class NotPlayerEntityAttrStrategy : IEntityAttrStrategy
{
    public override void InitAttr(IEntityAttr entityAttr)
    {
        NotPlayerEntityAttr attri = entityAttr as NotPlayerEntityAttr;
        if (attri == null)
            return;


    }

    public override int GetAttackVal(IEntityAttr entityAttr)
    {
        return 5;
    }

    public override int GetDmgReduceVal(IEntityAttr entityAttr)
    {
        return 0;
    }
   
}
