using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageWeapon : MonoBehaviour
{
    // �ϴ� �ּ� ó�� (2.9 ���� �߰�)
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
