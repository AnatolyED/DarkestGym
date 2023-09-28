using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveAbilityData : AbilityData
{
    public abstract PassiveAbility GetAbility(BaseUnit abilityOwner);
}
