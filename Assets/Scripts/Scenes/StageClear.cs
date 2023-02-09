using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClear : BaseScene
{
    public override void Clear()
    {
        
    }
    // 스테이지 클리어 씬도 게임 오버 씬 처럼 구현 (2.5 추가)
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
