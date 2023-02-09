using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager
{
    private RoundField RoundField;                                                                                                                                                                                     

    public void setField(RoundField roundField) { this.RoundField = roundField; }
    // getField() -> 이 안의 Field형인 field 멤버 변수에 접근할 수 있도록 public으로 선언한 함수 이다. (1.17 재윤 추가)
    public RoundField getField() { return this.RoundField; }

    //public void WarningAttack(int[] indexs)
    //{
    //    field.WarningAttack(indexs);
    //}
    //public void Attack(int[] indexs)
    //{
    //    field.Damage(indexs);
    //}
}
