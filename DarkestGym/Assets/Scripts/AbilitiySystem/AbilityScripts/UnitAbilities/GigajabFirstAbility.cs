using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GigajabFirstAbility : PassiveAbility
{
    public GigajabFirstAbility(Image image, string name, BaseUnit abilityOwner) : base(image, name, abilityOwner)
    {

    }

    public override void Apply()
    {
        BuffsDataManager.Instance.GigajabFirstBuffData.GetBuff(AbilityOwner).Use();
    }
}
