using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSword : Weapon
{
    protected override void Init()
    {
        //weapon = "Player/Weapons/WoodSword";
        Damage = 1;
        base.Init();

    }
    public override int[ , ] CalculateAttackRange(int currentInd_X, int currentInd_Y)
    {
        int attackInd_X = currentInd_X, attackInd_Y = currentInd_Y;
        /*int[] pattern = new int[1];
        for (int i = 0; i < pattern.Length; i++)
        {
            currentInd += 3;
            pattern[i] = currentInd;

        }
        return pattern;*/
        attackInd_Y -= 1;

        if (attackInd_Y < 0) attackInd_Y = currentInd_Y;
        
        int[ , ] pattern = new int[ , ] { { attackInd_X, attackInd_Y } };
        return pattern;
    }
}
