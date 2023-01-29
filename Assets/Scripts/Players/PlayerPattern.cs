using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonsterPattern과 동일한 Player용 PlayerPattern
public abstract class PlayerPattern
{
    public abstract int[] calculateIndex(int currentInd);

}
