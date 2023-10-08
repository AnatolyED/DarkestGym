using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GigajabSecondAbility", menuName = "AbilityData/GigajabSecondAbility")]
public class GigajabSecondAbilityData : ActiveAbilityData
{
    [SerializeField] private int _duration;
    [SerializeField] private List<GameObject> _groundBlocks;

    public override ActiveAbility GetAbility(BaseUnit baseUnit)
    {
        return new GigajabSecondAbility(Image, Name, baseUnit, AbilityCost, Cooldown, _duration, _groundBlocks);
    }
}
