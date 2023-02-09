using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Odd_EvenPattern : MonsterPattern
{
    public override int[] calculateIndex(int currentInd)
    {
        // hard coding, ÀçÀ± Ãß°¡ (2.5)
        if(currentInd == 0)
        {
            int[] pattern = { 1, 3, 5, 7 };
            return pattern;
        }
        else if(currentInd == 1)
        {
            int[] pattern = { 0, 2, 4, 6, 8 };
            return pattern;
        }
        else if (currentInd == 2)
        {
            int[] pattern = { 0, 3, 5, 6, 2, 8 };
            return pattern;
        }
        else if (currentInd == 3)
        {
            int[] pattern = { 0, 1, 2, 6, 7, 8 };
            return pattern;
        }
        else
        {
            int[] pattern = { 0, 2, 3, 4, 5, 6, 8 };
            return pattern;
        }
    }
}
