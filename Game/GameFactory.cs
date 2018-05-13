using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFactory  {

    private static IEntityFactory m_entityFactory = null;
    //private static IWeaponFactory m_weaponFactory = null;

    public static IEntityFactory GetEntityFactory()
    {
        if (m_entityFactory == null)
            m_entityFactory = new EntityFactory();
        return m_entityFactory;
    }

	 
}
