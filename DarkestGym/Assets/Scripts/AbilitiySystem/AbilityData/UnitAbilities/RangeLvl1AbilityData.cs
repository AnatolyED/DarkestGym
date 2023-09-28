using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeLvl1Ability", menuName = "AbilityData/RangeLvl1Ability")]
public class RangeLvl1AbilityData : PassiveAbilityData
{
    public override PassiveAbility GetAbility(BaseUnit abilityOwner)
    {
        return new RangeLvl1Ability(Image, Name, abilityOwner);
    }
}
