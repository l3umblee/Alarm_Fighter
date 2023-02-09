using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// �� Ŭ������ PlayerTextŬ�����̸� FieldObject�� ��ӹ޾� ����. FieldObject�� MonoBehaviour�� ��ӹް� �ִ�. (1.17 ���� �߰�)
// Issue (1.17) ó�� ������ �� Ű���� �ѹ��� �����ϰ� ������
public class PlayerTest : FieldObject
{

    TimingManager timingManager;
    int maxHp = 5;
    int currentHp;


    HpBar hpBar;

    AttackZoneMonster monster;
    public int CurrentHp
    {
        get { return currentHp; }
        set
        {
            currentHp = value;
            hpBar.updateValue(currentHp);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;

        timingManager = FindObjectOfType<TimingManager>();
        hpBar = Util.FindChild<HpBar>(gameObject, null, true);

        // type�� �ʱ�ȭ�ϰ� objectField�� �޾ƿ� ��, objectList�� PlayerField�� �޾ƿ´�.
        type = 1;
        objectField = Managers.Field.getField();
        objectList = objectField.getGridArray(type);

        currentInd = objectList.Count / 2; // �� �ʱ�ȭ�� ��ġ�� Field�� Width�� ���, ����� ������ �� ���� (1.18 ���� �߰�)
        transform.position = objectList[currentInd].transform.position;

        monster = FindObjectOfType<AttackZoneMonster>();
    }

    // Update is called once per frame
    void Update()
    {
        BitBehave();
    }

    protected override void BitBehave()
    {
        if (Input.GetKeyDown(KeyCode.W) && timingManager.CheckTiming()) { mayGo(Define.PlayerMove.Up); Managers.Sound.Play("Click"); }
        else if (Input.GetKeyDown(KeyCode.A) && timingManager.CheckTiming()) { mayGo(Define.PlayerMove.Left); Managers.Sound.Play("Click"); }
        else if (Input.GetKeyDown(KeyCode.S) && timingManager.CheckTiming()) { mayGo(Define.PlayerMove.Down); Managers.Sound.Play("Click"); }
        else if (Input.GetKeyDown(KeyCode.D) && timingManager.CheckTiming()) { mayGo(Define.PlayerMove.Right); Managers.Sound.Play("Click"); }
        else if (Input.GetKeyDown(KeyCode.K) && timingManager.CheckTiming()) { Attack(); Managers.Sound.Play("KnifeAttack1"); }
    }

    protected override void Attack()
    {
        /*
        int[] pattern = GetComponent<Weapon>().CalculateAttackRange(currentInd);
        Managers.Field.WarningAttack(pattern);
        Managers.Field.Attack(pattern);
        */
        Transform attack = transform.GetChild(0);
        attack.GetComponent<PlayerAttack>().Attacking();
        monster.MonsterHit();
    }

    protected override void Hit()
    {
        GetComponent<Animator>().SetTrigger("isHit");
        CurrentHp -= 1;
        Managers.Sound.Play("Hit");
        if (CurrentHp <= 0)
            Die();

    }
    void Die()
    {
        Debug.Log("Player Die!!");
        Managers.Game.GameOver();
        Managers.Sound.Play("Die");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackZone")
        {
            Attack();
            Managers.Timing.isIn = true;

            collision.gameObject.name = "NormalZone";

            PolygonCollider2D poly = collision.gameObject.GetComponent<PolygonCollider2D>();
            SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();

            sr.color = new Color(87 / 255f, 87 / 255f, 87 / 255f);
            poly.enabled = false;

            Managers.Field.ActivateAttackZone();
        }
        else if (collision.gameObject.name == "HitZone")
        {
            collision.gameObject.name = "NormalZone";
            Debug.Log("hit");
            Hit();
        }
        else return;
    }
}
