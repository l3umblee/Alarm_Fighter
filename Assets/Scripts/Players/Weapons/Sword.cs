using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    public Sword()
    {
        //weaponObject = Managers.Resource.Load<GameObject>("Prefabs/Items/Weapons/Sword");
        weaponObject = Managers.Resource.Load<GameObject>("Player/Weapons/Sword");
    }
}
