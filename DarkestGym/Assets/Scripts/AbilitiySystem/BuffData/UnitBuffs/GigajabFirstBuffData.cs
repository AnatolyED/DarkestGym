using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GigajabFirstBuff", menuName = "BuffData/GigajabFirstBuff")]
public class GigajabFirstBuffData : InfinityBuffData
{
    [SerializeField] private float _damageLimit;
    [SerializeField] private float _counterDamage;

    public override InfinityBuff GetBuff(BaseUnit buffOwner)
    {
        return new GigajabFirstBuff(Image, Name, buffOwner, _damageLimit, _counterDamage);
    }
}
