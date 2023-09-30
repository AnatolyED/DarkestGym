using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class FeiChaoFirstAbilityData : ActiveAbilityData
{
    [SerializeField] private int _abilityCost;
    [SerializeField] private int _abilityCooldowm;

    public override ActiveAbility GetAbility(BaseUnit abilityOwner)
    {
        return new FeiChaoFirstAbility(Image, Name, abilityOwner, _abilityCost, _abilityCooldowm);
    }
}
