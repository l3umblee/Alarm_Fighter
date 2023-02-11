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
    // int Damage -> protected int Damage�� ���� (2.9 ���� �߰�)
    protected int Damage;
    // virtual�� override �ǵ��� ���� ���� (2.9���� �߰�)
    protected virtual void Init()
    {

    }

    public void Attack()
    {
        //to do : ����Ʈ ��ȯ
    }

    public void WeaponDestroy()
    {

    }
    // 2���� �迭�� �ٷ��ֱ� ������ ��ȯ�� ���� (2.9 ���� �߰�)
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
