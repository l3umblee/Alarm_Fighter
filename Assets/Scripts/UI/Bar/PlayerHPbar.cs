using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPbar : MonoBehaviour
{
    Slider playerHpbar;
    // Start is called before the first frame update
    void Start()
    {
        playerHpbar = GetComponent<Slider>();
        playerHpbar.value = 1;
    }

    // Update is called once per frame
    public void UpdateValue(int currentHp, int maxHp)
    {
        playerHpbar.value = (float)currentHp / (float)maxHp;
    }
}
