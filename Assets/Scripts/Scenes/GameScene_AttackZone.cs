using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene_AttackZone : BaseScene
{
    void Update()
    {
        Managers.Timing.UpdatePerBit();
        Managers.Game.CheckLeftMonster();
    }
    protected override void Init()
    {
        base.Init();
        Managers.Game.SetMonsterCount(monsterList.Count);
        SoundBgmPlay();
        SpawnMonster();
        SpawnBackground();
        SpawnNoteBar();
        SpawnPlayer();
        SpawnField();
    }
    public override void Clear()
    {
        monsterList.Clear();
        monsterListInd = 0;
    }
}
