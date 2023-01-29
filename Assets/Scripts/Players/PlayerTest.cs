using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 이 클래스는 PlayerText클래스이며 FieldObject를 상속받아 생성. FieldObject가 MonoBehaviour를 상속받고 있다. (1.17 재윤 추가)
// Issue (1.17) 처음 시작할 때 키보드 한번을 생략하고 시작함
public class PlayerTest : FieldObject
{

    TimingManager timingManager;
    PlayerPattern attackPattern = new DefaultOnetilePattern();
    PlayerHPbar hpBar;
    // Start is called before the first frame update
    void Start()
    {
        timingManager=FindObjectOfType<TimingManager>();

        // playerHPbar 구현 초기화 (1.29 재윤 추가)
        hpBar = GameObject.FindObjectOfType<PlayerHPbar>();

        // type을 초기화하고 objectField를 받아온 뒤, objectList에 PlayerField를 받아온다.
        type = 1;
        objectField = Managers.Field.getField();
        objectList = objectField.getGridArray(type);

        // maxHP와 currentHP 초기화 (1.25 재윤 추가)
        maxHP = 3;
        currentHP = maxHP;
        // playerHPbar 구현 초기화 (1.29 재윤 추가)
        hpBar.UpdateValue(currentHP, maxHP);

        currentInd = objectList.Count / 2; // 이 초기화의 위치는 Field의 Width가 어떻든, 가운데에 오게할 수 있음 (1.18 재윤 추가)
        transform.position = objectList[currentInd].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 좀 더 깔끔하게 게임을 멈출 수 있는 방법 필요 (1.29 재윤 추가)
        if (!Managers.isPlayingGame) return;
        BitBehave();
    }

    protected override void BitBehave()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (timingManager.CheckTiming())
            {
                mayGo(Define.PlayerMove.Up);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (timingManager.CheckTiming())
            {
                mayGo(Define.PlayerMove.Left);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (timingManager.CheckTiming())
            {
                mayGo(Define.PlayerMove.Down);
            }

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (timingManager.CheckTiming())
            {
                mayGo(Define.PlayerMove.Right);
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (timingManager.CheckTiming())
            {
                Attack();
            }
        }
        
    }

    protected override void Attack()
    {
        // Hierachy 상에서 Player 안의 애니메이션을 받아오겠다는 이야기
        Transform attack = transform.GetChild(0);
        attack.GetComponent<PlayerAttack>().Attacking();
        int[] pattern = attackPattern.calculateIndex(currentInd);
        Managers.Field.Attack(pattern);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentHP -= 1;
        hpBar.UpdateValue(currentHP, maxHP);
        if (currentHP <= 0)
        {
            Debug.Log("Game Over");
            Managers.isPlayingGame = false;
            return;
        }
    }
}
