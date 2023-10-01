using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

[CreateAssetMenu(fileName = "FeiChaoFirstAbility", menuName = "AbilityData/FeiChaoFirstAbility")]
public class FeiChaoFirstAbilityData : ActiveAbilityData
{
    public override ActiveAbility GetAbility(BaseUnit abilityOwner)
    {
        return new FeiChaoFirstAbility(Image, Name, abilityOwner, AbilityCost, Cooldown);
    }
}
