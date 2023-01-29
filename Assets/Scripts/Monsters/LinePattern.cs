using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePattern : MonsterPattern
{
    public override int[] calculateIndex(int currentInd)
    {
        // 몬스터가 자기 자신이 있는 자리의 인덱스는 공격하면 안됨 (1.29 재윤 수정)
        int[] pattern = new int[2];
        for(int i = 0; i < pattern.Length; i++)
        {
            currentInd += 3;
            pattern[i] = currentInd;

        }
        return pattern;
    }
}
