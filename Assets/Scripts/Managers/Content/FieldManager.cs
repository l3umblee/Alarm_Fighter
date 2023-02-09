using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager
{
    private Field field;

    public void setField(Field field) { this.field = field; }
    // getField() -> �� ���� Field���� field ��� ������ ������ �� �ֵ��� public���� ������ �Լ� �̴�. (1.17 ���� �߰�)
    public Field getField() { return this.field; }

    public void WarningAttack(int[] indexs)
    {
        field.WarningAttack(indexs);
    }
    public void Attack(int[] indexs)
    {
        field.Damage(indexs);
    }
    // ���� �߰� (2.5) -> AttackZone ������ ���� �Լ�
    public void ActivateAttackZone()
    {
        field.getAttackZone();
    }
    public void clearGridColor()
    {
        field.clearTileColor();
    }

}
