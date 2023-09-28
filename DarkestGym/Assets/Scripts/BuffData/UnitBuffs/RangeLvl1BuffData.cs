using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeLvl1Buff", menuName = "BuffData/RangeLvl1Buff")]
public class RangeLvl1BuffData : InfinityBuffData
{
    [SerializeField] private int _distanceToWeak;

    public int DistanceToWeak => _distanceToWeak;

    public override InfinityBuff GetBuff(BaseUnit abilityOwner)
    {
        return new RangeLvl1Buff(Image, Name, abilityOwner, DistanceToWeak);
    }
}
