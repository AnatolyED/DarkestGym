using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public abstract class ActiveAbility : Ability
{
    #region Private Vars
    private int _abilityCost;
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

    public ActiveAbility(Image image, string name, BaseUnit abilityOwner, int abilityCost, int cooldown) : base(image, name, abilityOwner)
    {
        _abilityCost = abilityCost;
        _cooldown = cooldown;
    }

    public abstract void StartPrepare();
    public abstract void StopPrepare();
    protected abstract void UseAbility();
}
