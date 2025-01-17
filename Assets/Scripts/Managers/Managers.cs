using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    // isPlayingGame을 Managers.cs에 추가(1.29 - 몬스터의 행동 초기화 위함 / 재윤 추가)
    static public bool isPlayingGame = false;

    static Managers _instance;
    public static Managers Instance { get { Init(); return _instance; } }

    #region Content
    BpmManager _bpm = new BpmManager();
    FieldManager _field = new FieldManager();
    GameManagerEx _game = new GameManagerEx();
    TimingManager _timing = new TimingManager();
    public static BpmManager Bpm { get { return Instance._bpm; } }
    public static FieldManager Field { get { return Instance._field; } }
    public static GameManagerEx Game { get { return Instance._game; } }
    public static TimingManager Timing { get { return Instance._timing; } }
    #endregion

    #region Core
    CollisionManager _collision = new CollisionManager();
    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    ScenceManagerEx _scene = new ScenceManagerEx();
    SoundManager _sound = new SoundManager();

    public static CollisionManager Collision { get { return Instance._collision; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static ScenceManagerEx SceneManagerEx { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }

    #endregion

    void Start()
    {
        Init();

    }

    void Update()
    {
        Timing.UpdatePerBit();
    }
    static void Init()
    {
        if (_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject() { name = "@Managers" };
                go.AddComponent<Managers>();

            }
            DontDestroyOnLoad(go);
            _instance = go.GetComponent<Managers>();

            //Manager Init
            _instance._pool.Init();
            _instance._bpm.Init();
            //_instance._timing.Init();
        }
    }

    public static void Clear()
    {
        //Manager Clear
        Pool.Clear();
    }
    // GameOver를 위한 함수 구현 (1.29 재윤 추가)
    private void GameOver()
    {
        // GameOver 구현해주기
    }
}
