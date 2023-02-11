using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon 
{
    public Define.ItemRank Rank { get; private set; }
    int attackRange;
    int numOfAttack;
    AnimationClip attackAnim;
    protected GameObject weaponObject;
    // int Damage -> protected int Damage로 수정 (2.9 재윤 추가)
    protected int Damage;
    // virtual이 override 되도록 선언만 해줌 (2.9재윤 추가)
    protected virtual void Init()
    {

    }

    public void Attack()
    {
        //to do : 이펙트 소환
    }

    public void WeaponDestroy()
    {

    }
    // 2차원 배열로 다뤄주기 때문에 반환형 수정 (2.9 재윤 추가)
    public virtual int[ , ] CalculateAttackRange(int row, int column)
    {
        return new int[1, 1];
    }

    public void Mount(GameObject parent)
    {
        GameObject go = Object.Instantiate(weaponObject);
        go.transform.SetParent(parent.transform);
        go.transform.localPosition = Vector3.zero;
    }
}
