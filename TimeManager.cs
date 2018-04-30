using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TimeManager: IGameSystem
{
    protected long m_startTicks = 0;
    protected long m_elapseTicks = 0;

    public long GetCurrentTicks()
    {
        return System.DateTime.Now.Ticks;
    }

    public long GetElpaseTicks()
    {
        return GetCurrentTicks() - m_startTicks;
    }

    public float GetCurrentTime()
    {
        return ((float)GetCurrentTicks()) / 1000f;
    }

    public float GetElapseTime()
    {
        return ((float)GetElpaseTicks()) / 1000f;
    }

    public TimeManager()
    {

    }

    public override void Initialize()
    {
        base.Initialize();
        m_startTicks = System.DateTime.Now.Ticks;
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
    }
     
}
