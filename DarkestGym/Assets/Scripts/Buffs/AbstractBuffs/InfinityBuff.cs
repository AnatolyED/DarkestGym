using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InfinityBuff : Buff
{
    public sealed override void Use()
    {
        ActivateBuff();
        GameManager.Instance.RoundManager.OnNextRound += OnMoveAction;
    }

    public sealed override void Unuse()
    {
        DeactivateBuff();
        GameManager.Instance.RoundManager.OnNextRound -= OnMoveAction;
    }
}
