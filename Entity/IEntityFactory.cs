using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class IEntityFactory
{
    public abstract PlayerEntity CreatePlayerEntity(EntityType enttiyType, EWeaponType curWeapon, Vector3 spawnPoint);

    public abstract NotPlayerEntity CreateNotPlayerEntity(EntityType enttiyType, EWeaponType curWeapon, Vector3 spawnPoint);

}
