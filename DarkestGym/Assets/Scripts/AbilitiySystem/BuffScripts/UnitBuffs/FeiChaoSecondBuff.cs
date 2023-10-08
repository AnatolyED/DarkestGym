using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeiChaoSecondBuff : InfinityBuff
{
    public float HpExtend { get; private set; }
    public float DamageExtend { get; private set; }

    public int ChargesCount { get; private set; }

    public FeiChaoSecondBuff(Image image, string name, BaseUnit buffOwner, float hpExtend, float damageExtend) : base(image, name, buffOwner)
    {
        HpExtend = hpExtend;
        DamageExtend = damageExtend;
    }

    protected override void ActivateBuff()
    {
        BuffOwner.OnKilled += BuffLogic;
    }

    protected override void DeactivateBuff()
    {
        BuffOwner.OnKilled -= BuffLogic;
        BuffOwner.Health -= ChargesCount * HpExtend;
        BuffOwner.Damage -= ChargesCount * DamageExtend;
    }

    protected override void OnMoveAction()
    {

    }

    private void BuffLogic(BaseUnit killedUnit)
    {
        BuffOwner.Health += HpExtend;
        BuffOwner.Damage += DamageExtend;
        ChargesCount++;
    }
}
