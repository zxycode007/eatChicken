using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public abstract class IEntity
{
    protected string m_name;
    protected GameObject m_gameObj;
    protected NavMeshAgent m_navAgent;
    protected AudioSource m_audio;

    protected bool m_bKilled = false;
    protected float m_removeTime = 5.0f;
    protected bool m_canBeRemove = true;

    public IEntity()
    {

    }

    public void BindGameObject(GameObject go)
    {
        m_gameObj = go;
    }

    public GameObject GetGameObject()
    {
        return m_gameObj;
    }

    public void Release()
    {

    }

    public string name { get { return m_name; } set { m_name = value; } }


}
