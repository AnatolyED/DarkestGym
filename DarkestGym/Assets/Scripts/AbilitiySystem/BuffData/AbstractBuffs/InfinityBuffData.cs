using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InfinityBuffData : BuffData
{
    public abstract InfinityBuff GetBuff(BaseUnit buffOwner);
}
