using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager :MonoBehaviour
{
    //GameObject _root;
    // �����Ǵ� �� note�� ���� List
    public List<GameObject> noteList = new List<GameObject>();

    // AttackZone�� ������ �� true�� ��ȯ -> ���� �߰�(2.5)
    public bool isIn = true;

    [SerializeField] Transform centerFlame=null;
       /* = GameObject.Find("CenterFlame").transform;*/  //CenterFlame�� ��ġ

    
    [SerializeField] RectTransform[] timingRect=null;
        /*={
        GameObject.Find("PerfectRec").GetComponent<RectTransform>(),
        GameObject.Find("CoolRec").GetComponent<RectTransform>(),
        GameObject.Find("GoodRec").GetComponent<RectTransform>(),
        GameObject.Find("BadRec").GetComponent<RectTransform>()
    };*/ //�����ִ� �̹��� �ڽ�
    Vector2[] timingRange = null; //timingRect�� x����

    /*public void Init()
    {
         timingRange = new Vector2[timingRect.Length]; //ũ�� 4

        for (int i = 0; i < timingRect.Length; i++)
        {
            //timingRange[0]�� perfectRect�� ���� ��
            timingRange[i] = new Vector2(timingRect[i].localPosition.x - timingRect[i].rect.width / 2,
                timingRect[i].anchoredPosition.x + timingRect[i].rect.width / 2);
        }

        _root = GameObject.Find("Note2");
    }*/

    public bool isStart = false;
    void Start()
    {
        timingRange = new Vector2[timingRect.Length]; //ũ�� 4

        for (int i = 0; i < timingRect.Length; i++)
        {
            //timingRange[0]�� perfectRect�� ���� ��
            timingRange[i] = new Vector2(timingRect[i].localPosition.x - timingRect[i].rect.width / 2,
                timingRect[i].anchoredPosition.x + timingRect[i].rect.width / 2);
        }
    }

    //������ Note�� timingRange�� ���ϴ� Note�� �ִ��� Ȯ��
    public bool CheckTiming()
    {
        for (int i = 0; i < noteList.Count; i++)//������ Note�� ���� Ȯ��
        {
            float notePosx = noteList[i].transform.localPosition.x;// Note�Ѱ��� x��

            for (int j = 0; j < timingRange.Length; j++)//4���� timingRange�� ���ϴ� Ȯ��
            {
                if ((timingRange[j].x <= notePosx) && (notePosx <= timingRange[j].y))
                {
                    //Note�� timingRange�� ���ϸ� �ش� Note ����
                    //Destroy(noteList[i]);
                    Managers.Bpm.Able = true;//������
                    noteList[i].GetComponent<Note>().HideNote();//Note ���� ��ſ� Note�� �̹����� ��Ȱ��ȭ//����: BGM�� �� ����
                    noteList.RemoveAt(i);
                    //Debug.Log("HIT" + j);
                    return true;
                }
            }
        }


        Debug.Log("Miss");//������ Note���� timingRange�� ������ ������ Miss
        return false;
    }


    public Action BehaveAction;
    double currentTime = 0;
    
    public void UpdatePerBit()
    {
        if (!Managers.isPlayingGame) return;
        currentTime += Time.deltaTime;
        if(currentTime >= 60d /Managers.Bpm.BPM)
        {
            Debug.Log(isIn);
            Managers.Field.clearGridColor();
            if(BehaveAction != null)
                BehaveAction.Invoke();

            //Managers.Field.ActivateAttackZone();
            if(isIn)
            {
                Debug.Log("ActivateAttackZone()");
                Managers.Field.ActivateAttackZone();
                isIn = false;
            }
            currentTime -= 60d / Managers.Bpm.BPM;
        }
    }
    public void Clear()
    {
        // ���� �߰� (2.5)
        Managers.isPlayingGame = false;
        noteList = null; timingRange = null; timingRange = null;
        BehaveAction = null;
    }
}
