using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHPbar : MonoBehaviour
{
    Slider monsterHpbar;
    // Start is called before the first frame update
    void Start()
    {
        monsterHpbar = GetComponent<Slider>();
        monsterHpbar.value = 1;
    }

    // Update is called once per frame
    public void UpdateValue(int currentHp, int maxHp)
    {
        monsterHpbar.value = (float)currentHp / (float)maxHp;
    }
}
