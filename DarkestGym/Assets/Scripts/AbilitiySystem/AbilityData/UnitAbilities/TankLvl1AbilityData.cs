using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "TankLvl1Ability", menuName = "AbilityData/TankLvl1Ability")]
public class TankLvl1AbilityData : PassiveAbilityData
{
    public override PassiveAbility GetAbility(BaseUnit abilityOwner)
    {
        return new TankLvl1Ability(Image, Name, abilityOwner);
    }
}
