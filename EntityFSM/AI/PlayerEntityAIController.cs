using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerEntityAIController : IEntityAIController
{

    public PlayerEntityAIController(IEntity entity):base(entity)
    {
        SwitchEntityAIState(new IdleAIState());
    }
     
}
