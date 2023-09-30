using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeiChaoFirstAbility : ActiveAbility
{
    private BaseUnit _target;

    public FeiChaoFirstAbility(Image image, string name, BaseUnit abilityOwner, int abilityCost, int cooldown) : 
        base(image, name, abilityOwner, abilityCost, cooldown)
    {

    }

    public override void StartPrepare()
    {

    }

    public override void StopPrepare()
    {

    }

    protected override void UseAbiltiy()
    {

    }
}
