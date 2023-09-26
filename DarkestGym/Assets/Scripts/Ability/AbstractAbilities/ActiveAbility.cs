using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveAbility : Ability
{
    #region Limits
    [Space]
    [Header("����������� �� ��������� �����������")]
    [SerializeField] private const int _minAbilityCost = 0;
    [SerializeField] private const int _maxAbilityCost = 1000;
    #endregion

    #region Private Vars
    [Space]
    [Header("��������� �����������")]
    [SerializeField]
    [Range(_minAbilityCost, _maxAbilityCost)]
    private int _abilityCost;
    #endregion

    #region Properties
    public int AbilityCost
    {
        get { return _abilityCost; }
        set 
        { 
            _abilityCost = Math.Min(Math.Max(_minAbilityCost, value), _maxAbilityCost);
        }
    }
    #endregion

    public abstract void StartPrepare();
    public abstract void StopPrepare();
    protected abstract void UseAbiltiy();
}
