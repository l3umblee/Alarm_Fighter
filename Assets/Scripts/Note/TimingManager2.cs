using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TimingManager2 : MonoBehaviour
{


  /*  // 생성되는 흰 note를 넣을 List
    public List<GameObject> noteList = new List<GameObject>();

    [SerializeField] Transform centerFlame = null;  //CenterFlame의 위치
    [SerializeField] RectTransform[] timingRect = null; //색깔있는 이미지 박스
    Vector2[] timingRange = null; //timingRect의 x범위

    void Start()
    {
        timingRange = new Vector2[timingRect.Length]; //크기 4

        for (int i = 0; i < timingRect.Length; i++)
        {
            //timingRange[0]이 perfectRect의 범위 순
            timingRange[i] = new Vector2(timingRect[i].localPosition.x - timingRect[i].rect.width / 2,
                timingRect[i].anchoredPosition.x + timingRect[i].rect.width / 2);
        }
    }

    //생성된 Note중 timingRange에 속하는 Note가 있는지 확인
    public void CheckTiming()
    {
        for (int i = 0; i < noteList.Count; i++)//생성된 Note를 전부 확인
        {
            float notePosx = noteList[i].transform.localPosition.x;// Note한개의 x값

            for(int j = 0; j < timingRange.Length; j++)//4개의 timingRange와 접하는 확인
            {
                if((timingRange[j].x <= notePosx) && (notePosx <= timingRange[j].y))
                {
                    //Note가 timingRange에 속하면 해당 Note 삭제
                    //Destroy(noteList[i]);
                    noteList[i].GetComponent<Note>().HideNote();//Note 삭제 대신에 Note의 이미지만 비활성화//이유: BGM이 안 나옴
                    noteList.RemoveAt(i);
                    Debug.Log("HIT" + j);
                    return;
                }
            }
        }


        Debug.Log("Miss");//생성된 Note전부 timingRange에 속하지 않으면 Miss
    }*/
    
}
