using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Parent : MonoBehaviour
{
    // Player�� �������� ����� ������ 
    protected int current_X, current_Y;
    protected int move_X, move_Y;

    // Weapon ȹ�� �� �������ֱ�  ���� �迭
    protected List<Weapon> playerWeapon;
    void Start()
    {
        current_X = 5;
        current_Y = 1;
        this.transform.position = Managers.Field.GetGrid(current_X, current_Y).transform.position;
        ChangeSize(current_Y);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    protected void PlayerMove()
    {
        if (Input.GetKeyDown(KeyCode.W)) { mayGo(Define.PlayerMove.Up); }
        else if (Input.GetKeyDown(KeyCode.A)) { mayGo(Define.PlayerMove.Left); }
        else if (Input.GetKeyDown(KeyCode.S)) { mayGo(Define.PlayerMove.Down); }
        else if (Input.GetKeyDown(KeyCode.D)) { mayGo(Define.PlayerMove.Right); }
    }

    protected void mayGo(Define.PlayerMove playerMove)
    {
        move_X = current_X;
        move_Y = current_Y;
        // ������ �� �ִ� �ε������� �˻�
        if (playerMove == Define.PlayerMove.Up)
        {
            move_Y -= 1;
            if (move_Y < 0)
                move_Y = current_Y;
        }
        else if (playerMove == Define.PlayerMove.Down)
        {
            move_Y += 1;
            if (move_Y > Managers.Field.GetHeight() - 1)
                move_Y = current_Y;
        }
        else if (playerMove == Define.PlayerMove.Left)
        {
            move_X -= 1;
            if (move_X < 0)
                move_X = current_X;
        }
        else if (playerMove == Define.PlayerMove.Right)
        {
            move_X += 1;
            if (move_X > Managers.Field.GetWidth() - 1)
                move_X = current_X;
        }
        this.transform.position = Managers.Field.GetGrid(move_X, move_Y).transform.position;
        current_X = move_X;
        current_Y = move_Y;

        ChangeSize(current_Y);
    }
    // ���ٰ��� ����� ���� ���ؼ��� ������ �ٲٸ� �� (2.11 ���� �߰�)
    protected void ChangeSize(int currentInd_Y)
    {
        Vector3 size = new Vector3((float)(currentInd_Y + 1) * 0.7f, (float)(currentInd_Y + 1) * 0.7f, (float)(currentInd_Y + 1) * 0.7f);
        this.transform.localScale = size;
    }
    // to do : Weapon ȹ�� ��� �����غ��� 
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Debug.Log(collision.gameObject.name);
            //playerWeapon.Add(new Sword());
            Destroy(collision.gameObject);
        }
    }
}
