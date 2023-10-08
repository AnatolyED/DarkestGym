using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeiChaoSecondAbility : PassiveAbility
{
    public FeiChaoSecondAbility(Image image, string name, BaseUnit abilityOwner) : base(image, name, abilityOwner) { }

    public override void Apply()
    {
        BuffsDataManager.Instance.FeiChaoSecondBuffData.GetBuff(AbilityOwner).Use();
    }
}
