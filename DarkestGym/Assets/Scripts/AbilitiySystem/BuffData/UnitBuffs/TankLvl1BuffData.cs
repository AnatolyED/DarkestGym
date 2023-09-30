using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "TankLvl1Buff", menuName = "BuffData/TankLvl1Buff")]
public class TankLvl1BuffData : InfinityBuffData
{
    [SerializeField] public float _returnDamageMult;

    public float ReturnDamageMult => _returnDamageMult;

    public override InfinityBuff GetBuff(BaseUnit abilityOwner)
    {
        return new TankLvl1Buff(Image, Name, abilityOwner, ReturnDamageMult);
    }
}
