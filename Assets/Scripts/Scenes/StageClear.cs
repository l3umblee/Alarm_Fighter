using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : BaseScene
{
    public override void Clear()
    {
        
    }
    // �������� Ŭ���� ���� ���� ���� �� ó�� ���� (2.5 �߰�)
    protected override void Init()
    {
        base.Init();
        SoundBgmPlay();
        Invoke("ReturnStage", 5);
    }

    void ReturnStage()
    {
        Managers.Scene.LoadScene("Stage2");
    }
}
