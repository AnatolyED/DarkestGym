using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveAbilityData : AbilityData
{
    #region Private Vars
    [Space]
    [Header("Стоимость способности")]
    [SerializeField]
    [Range(0, 1000)]
    private int _abilityCost;

    [Space]
    [Header("Откат способности")]
    [SerializeField]
    [Range(0, 1000)]
    private int _cooldown;
    #endregion

    #region Properties
    public int AbilityCost
    {
        get { return _abilityCost; }
        set
        {
            _abilityCost = Math.Max(0, value);
        }
    }

    public int Cooldown
    {
        get { return _cooldown; }
        set
        {
            _cooldown = Math.Max(0, value);
        }
    }
    #endregion

    public abstract ActiveAbility GetAbility(BaseUnit abilityOwner);
}
