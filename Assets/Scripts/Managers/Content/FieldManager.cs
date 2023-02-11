using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager
{
    private RoundField roundField;

    public void setField(RoundField roundField) { this.roundField = roundField; }
    // getField() -> �� ���� Field���� field ��� ������ ������ �� �ֵ��� public���� ������ �Լ� �̴�. (1.17 ���� �߰�)
    public RoundField getField() { return this.roundField; }
    public List<List<FieldInfo>> GetGridArray() { return roundField.GetGridArray(); }
    public GameObject GetGrid(int latitude, int longtitude) { return roundField.GetGrid(latitude, longtitude); }
    public int GetHeight() { return roundField.GetHeight();}
    public int GetWidth() { return roundField.GetWidth(); }
}