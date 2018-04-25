using UnityEngine;
using System.Collections;

public enum EWeaponType
{
    AK_47,
    M_16,
    Knife,
    NULL
}

//武器接口
public class IWeapon
{

    protected EWeaponType m_weaponType = EWeaponType.NULL;
    protected int m_atkVal = 0;
    protected int m_atkRange = 0;
    protected IEntity m_owner = null;
    public GameObject m_gameObj = null;

    public IEntity Owner { get { return m_owner; } set { m_owner = value; } }
    public GameObject gameObject { get { return m_gameObj; } }

    public EWeaponType weaponType { get { return m_weaponType; } }

    public IWeapon(EWeaponType type, int attackValue, int attackRange)
    {
        m_weaponType = type;
        m_atkRange = attackRange;
        m_atkVal = attackValue;
    }

    public void Fire(IEntity target)
    {

    }

    public void ShowBulletEffect(Vector3 targetPos, float lineWidth, float showTime)
    {

    }


    public void ShowShootEffect(Vector3 targetPos, float lineWidth, float showTime)
    {

    }

    public void ShowSoundEffect(string soundClipName)
    {

    }
}
