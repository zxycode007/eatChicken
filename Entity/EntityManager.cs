using UnityEngine;
using System.Collections;

public class EntityManager : IGameSystem
{

    public EntityManager()
    {

    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Update()
    {
        base.Update();
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
