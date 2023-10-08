using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LinnetSecondAbility", menuName = "AbilityData/LinnetSecondAbility")]
public class LinnetSecondAbilityData : ActiveAbilityData
{
    public override ActiveAbility GetAbility(BaseUnit abilityOwner)
    {
        return new LinnetSecondAbility(Image, Name, abilityOwner, AbilityCost, Cooldown);
    }
}
