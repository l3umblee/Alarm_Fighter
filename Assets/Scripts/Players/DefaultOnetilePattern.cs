using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Player 공격 패턴을 위한 PlayerPattern 클래스 (1.29 재윤 추가)
public class DefaultOnetilePattern : PlayerPattern
{
    public override int[] calculateIndex(int currentInd)
    {
        // pattern 배열은 공격할 배열의 인덱스들이 담김 (1.29 재윤 추가)
        int[] pattern = new int[1];
        for (int i = 0; i < pattern.Length; i++)
        {
            currentInd += 3;
            pattern[i] = currentInd;
            Debug.Log(currentInd);
        }
        return pattern;
    }
}
