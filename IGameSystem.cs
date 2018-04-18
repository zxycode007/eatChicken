using UnityEngine;
using System.Collections;

public class IGameSystem
{
    protected GameEventContext mEvtCtx;

    public IGameSystem() 
    {
        mEvtCtx = new GameEventContext();
    }

    public virtual void Initialize(){}
    public virtual void Update(){}
    public virtual void Release(){}

}
