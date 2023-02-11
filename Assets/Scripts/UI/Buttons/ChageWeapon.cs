using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageWeapon : MonoBehaviour
{
    // 일단 주석 처리 (2.9 재윤 추가)
    public void toWoodSword()
    {
        GameObject go = Managers.Game.CurrentPlayer;
        //Destroy(go.GetComponent<Weapon>());

        //go.AddComponent<WoodSword>();
    }

    public void toDiaSword()
    {
        GameObject go = Managers.Game.CurrentPlayer;

        //Destroy(go.GetComponent<Weapon>());

        //go.AddComponent<Sword>();

    }
}
