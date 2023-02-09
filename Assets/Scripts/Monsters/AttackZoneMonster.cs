using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZoneMonster : FieldObject
{
    int currentHp, maxHp = 10; 
    Define.State nextBehavior = Define.State.MOVE;
    MonsterPattern attackPattern = new Odd_EvenPattern();
    void Start()
    {
        currentHp = maxHp;

        Managers.Timing.BehaveAction -= BitBehave;
        Managers.Timing.BehaveAction += BitBehave;
    }

    protected override void BitBehave()
    {
        //Animator anim = GetComponent<Animator>();
        switch (nextBehavior)
        {
            case Define.State.ATTACKREADY:
                //anim.Play("EvilEye_AttackReady");
                updateAtttackReady();
                break;
            case Define.State.ATTACK:
                //anim.Play("EvilEye_Attack");
                updateAttack();
                break;
            case Define.State.MOVE:
                updateMove();
                break;
        }
    }
    void updateMove()
    {
        // 몬스터가 고정이므로 현재 인덱스 대신 pattern type으로 변경 (2.5)
        currentInd = Random.Range(0, 6);
        nextBehavior = Define.State.ATTACKREADY;
    }
    void updateAtttackReady()
    {
        AttackReady();
        nextBehavior = Define.State.ATTACK;
    }
    void updateAttack()
    {
        Attack();
        nextBehavior = Define.State.MOVE;
    }
    protected override void Attack()
    {
        int[] pattern = attackPattern.calculateIndex(currentInd);
        Managers.Field.Attack(pattern);
    }
    void AttackReady()
    {
        int[] pattern = attackPattern.calculateIndex(currentInd);
        Managers.Field.WarningAttack(pattern);
    }
    public void MonsterHit()
    {
        currentHp -= 1;
        if (currentHp <= 0)
            Die();
    }
    void Die()
    {
        Debug.Log("MonsterDIe!");
        Destroy(gameObject);
        Managers.Game.StageClear();
    }
}
