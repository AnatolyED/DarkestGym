using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InfinityBuff : Buff
{
    public InfinityBuff(Image image, string name, BaseUnit buffOwner) : base(image, name, buffOwner)
    {

    }

    public sealed override void Use()
    {
        ActivateBuff();
        GameManager.Instance.RoundManager.OnNextRound += OnMoveAction;
        BuffOwner.BuffManager.AddInfinnityBuff(this);
    }

    public sealed override void Unuse()
    {
        DeactivateBuff();
        GameManager.Instance.RoundManager.OnNextRound -= OnMoveAction;
        BuffOwner.BuffManager.RemoveInfinityBuff(this);
    }
}
