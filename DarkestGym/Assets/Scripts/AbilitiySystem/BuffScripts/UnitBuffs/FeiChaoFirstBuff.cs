using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeiChaoFirstBuff : TemporaryBuff
{
    public int ScoreIncrease { get; private set; }
    public int AfterKillExtend { get; private set; }

    public FeiChaoFirstBuff(Image image, string name, BaseUnit buffOwner, int duration, int scoreIncrease, int afterKillExtend) : base(image, name, buffOwner, duration)
    {
        ScoreIncrease = scoreIncrease;
        AfterKillExtend = afterKillExtend;
    }

    protected override void ActivateBuff()
    {
        BuffOwner.ScorePoint += ScoreIncrease;
        BuffOwner.OnKilled += BuffLogic;
    }

    protected override void DeactivateBuff()
    {
        BuffOwner.ScorePoint -= ScoreIncrease;
        BuffOwner.OnKilled -= BuffLogic;
    }

    protected override void OnMoveAction()
    {

    }
    
    private void BuffLogic(BaseUnit killedUnit)
    {
        MovesLeft += AfterKillExtend;
    }
}
