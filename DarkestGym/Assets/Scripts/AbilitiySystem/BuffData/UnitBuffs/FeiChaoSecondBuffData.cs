using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FeiChaoSecondBuff", menuName = "BuffData/FeiChaoSecondBuff")]
public class FeiChaoSecondBuffData : InfinityBuffData
{
    [SerializeField] private float _hpExtend;
    [SerializeField] private float _damageExtend;

    public override InfinityBuff GetBuff(BaseUnit buffOwner)
    {
        return new FeiChaoSecondBuff(Image, Name, buffOwner, _hpExtend, _damageExtend);
    }
}
