using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    [SerializeField]
    protected string soundBgmName;
    
    // 재윤 추가 (2.5) -> 부모 클래스 정비
    [SerializeField]
    protected List<GameObject> monsterList = new List<GameObject>();
    protected int monsterListInd;
    [SerializeField]
    protected GameObject background;

    private void Awake()
    {
        Init();
    }
    protected virtual void Init()
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if(obj == null)
        {
            Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
        }
    }
    public abstract void Clear();
    protected void SoundBgmPlay()
    {
        Managers.Sound.Play(soundBgmName, Define.Sound.Bgm);
    }

    // 재윤 추가 (2.5)
    protected void SpawnMonster()
    {
        GameObject go = Instantiate(monsterList[monsterListInd]) as GameObject;
    }
    protected void SpawnBackground()
    {
        GameObject go = Instantiate(background) as GameObject;
        go = Instantiate<GameObject>(go) as GameObject;
    }
    protected void SpawnNoteBar()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/NoteBar/NoteBar");
        go = Instantiate(go) as GameObject;
    }
    protected void SpawnPlayer()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Player/Player");
        go = Instantiate<GameObject>(go) as GameObject;
        Managers.Game.CurrentPlayer = go;
    }
    protected void SpawnField()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Fields/Field");
        go = Instantiate<GameObject>(go) as GameObject;
    }
}
