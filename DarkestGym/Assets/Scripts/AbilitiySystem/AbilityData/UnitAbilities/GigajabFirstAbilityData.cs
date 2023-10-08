using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GigajabFirstAbility", menuName = "AbilityData/GigajabFirstAbility")]
public class GigajabFirstAbilityData : PassiveAbilityData
{
    public override PassiveAbility GetAbility(BaseUnit abilityOwner)
    {
        return new GigajabFirstAbility(Image, Name, abilityOwner);
    }
}
