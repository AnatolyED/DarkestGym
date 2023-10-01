using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "FeiChaoFirstBuff", menuName = "BuffData/FeiChaoFirstBuff")]
public class FeiChaoFirstBuffData : TemporaryBuffData
{
    [SerializeField] private int _scoreIncrease;
    [SerializeField] private int _afterKillExtend;

    public int ScoreIncrease => _scoreIncrease;
    public int AfterKillExtend => _afterKillExtend;

    public override TemporaryBuff GetBuff(BaseUnit abilityOwner)
    {
        return new FeiChaoFirstBuff(Image, Name, abilityOwner, Duration, _scoreIncrease, _afterKillExtend);
    }
}
