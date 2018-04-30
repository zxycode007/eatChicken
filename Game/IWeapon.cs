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
public abstract class IWeapon
{

    protected EWeaponType m_weaponType = EWeaponType.NULL;
    protected int m_atkVal = 0;
    protected int m_atkRange = 0;
    protected IEntity m_owner = null;
    public GameObject m_gameObj = null;

    public int attackValue
    {
        get { return m_atkVal; }
        set { m_atkVal = value; }
    }

    public int attackRange
    {
        get { return m_atkRange; }
        set { m_atkRange = value; }
    }

    public IEntity Owner { get { return m_owner; } set { m_owner = value; } }
    public GameObject gameObject { get { return m_gameObj; } }

    public EWeaponType weaponType { get { return m_weaponType; } }

    public IWeapon(EWeaponType type, int attackValue, int attackRange)
    {
        m_weaponType = type;
        m_atkRange = attackRange;
        m_atkVal = attackValue;
    }

    //模板方法
    public void Fire(IEntity target)
    {
        
        //流程定义
        DoShowShootEffect(); //步骤1
        DoShootBulletEffect(target); //步骤2
        DoShootSoundEffect(); //步骤3

    }

   
    public abstract void DoShootBulletEffect(IEntity target);

    public abstract void DoShootSoundEffect();
 
    public abstract void DoShowShootEffect();

    public void ShowSoundEffect(string soundClipName)
    {

    }
}
