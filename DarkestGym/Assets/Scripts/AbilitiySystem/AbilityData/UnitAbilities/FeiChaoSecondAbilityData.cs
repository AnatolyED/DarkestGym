using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FeiChaoSecondAbility", menuName = "AbilityData/FeiChaoSecondAbility")]
public class FeiChaoSecondAbilityData : PassiveAbilityData
{
    public override PassiveAbility GetAbility(BaseUnit abilityOwner)
    {
        return new FeiChaoSecondAbility(Image, Name, abilityOwner);
    }
}
