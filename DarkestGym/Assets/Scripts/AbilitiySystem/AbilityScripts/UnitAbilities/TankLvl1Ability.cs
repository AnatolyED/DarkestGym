using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankLvl1Ability : PassiveAbility
{
    public TankLvl1Ability(Image image, string name, BaseUnit abilityOwner) : base(image, name, abilityOwner)
    {

    }

    public override void Apply()
    {
        InfinityBuff buff = BuffsDataManager.Instance.TankLvl1AbilityData.GetBuff(AbilityOwner);
        buff.Use();
    }
}
