using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager
{
    private RoundField roundField;

    public void setField(RoundField roundField) { this.roundField = roundField; }
    // getField() -> 이 안의 Field형인 field 멤버 변수에 접근할 수 있도록 public으로 선언한 함수 이다. (1.17 재윤 추가)
    public RoundField getField() { return this.roundField; }
    public List<List<FieldInfo>> GetGridArray() { return roundField.GetGridArray(); }
    public GameObject GetGrid(int latitude, int longtitude) { return roundField.GetGrid(latitude, longtitude); }
    public int GetHeight() { return roundField.GetHeight();}
    public int GetWidth() { return roundField.GetWidth(); }
}