using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TemporaryBuff : Buff
{
    #region Private Vars
    private int _duration;
    private int _movesLeft;
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

    public int MovesLeft
    {
        get { return _movesLeft; }
        set
        {
            if(value <= 0) DeactivateBuff();
            _movesLeft = Math.Max(0, value);
        }
    }
    #endregion

    public TemporaryBuff(Image image, string name, BaseUnit buffOwner, int duration) : base(image, name, buffOwner)
    {
        _duration = duration;
        _movesLeft = _duration;
    }
    
    public sealed override void Use()
    {
        ActivateBuff();
        GameManager.Instance.RoundManager.OnNextRound += TimerReducer;
        GameManager.Instance.RoundManager.OnNextRound += OnMoveAction;
        BuffOwner.BuffManager.AddTemporaryBuff(this);
    }

    public sealed override void Unuse()
    {
        MovesLeft = 0;
        GameManager.Instance.RoundManager.OnNextRound -= TimerReducer;
        GameManager.Instance.RoundManager.OnNextRound -= OnMoveAction;
        BuffOwner.BuffManager.RemoveTemporaryBuff(this);
    }

    private void TimerReducer()
    {
        MovesLeft--;
    }
}
