using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PassiveAbility : Ability
{
    public abstract void Apply();

    public PassiveAbility(Image image, string name, BaseUnit abilityOwner) : base(image, name, abilityOwner)
    {

    }
}
