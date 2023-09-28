using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TemporaryBuffData : BuffData
{
    #region Private Vars
    [Space]
    [SerializeField]
    [Range(0, 1000)]
    [Header("Длительность способности (в ходах)")]
    private int _duration;
    #endregion

    #region Properties
    public int Duration
    {
        get { return _duration; }
        set
        {
            _duration = Math.Max(0, value);
        }
    }
    #endregion

    public abstract TemporaryBuff GetBuff(BaseUnit buffOwner);
}
