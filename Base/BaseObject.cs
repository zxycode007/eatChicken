﻿using UnityEngine;
using System.Collections;

public class BaseObject : MonoBehaviour
{

    protected GameEventContext mEvtCtx = new GameEventContext();
    protected PropertySystem mPropSys = new PropertySystem();

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 重新设初值
    /// </summary>
    public virtual void Reset()
    {

    }



    /// <summary>
    /// 回收处理方法
    /// </summary>
    public virtual void Recycle()
    {

    }


}
