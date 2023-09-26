using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TemporaryBuff : Buff
{
    #region Limits
    [Space]
    [Header("Ограничения на длительность способности (в ходах)")]
    [SerializeField] private const int _minDuration = 0;
    [SerializeField] private const int _maxDuration = 1000;
    #endregion

    #region Private Vars
    [Space]
    [SerializeField] 
    [Range(_minDuration, _maxDuration)]
    [Header("Длительность способности (в ходах)")]
    private int _duration;

    [Space]
    [SerializeField]
    [Range(_minDuration, _maxDuration)]
    [Header("Ходов осталось для иссякания способности")]
    private int _movesLeft;
    #endregion

    #region Properties
    public int Duration
    {
        get { return _duration; }
        set
        {
            _duration = Math.Min(Math.Max(_minDuration, value), _maxDuration);
        }
    }

    public int MovesLeft
    {
        get { return _movesLeft; }
        set
        {
            if (value > _minDuration && value <= _maxDuration)
            {
                _movesLeft = value;
            }
            else if (value <= _minDuration)
            {
                DeactivateBuff();
                _movesLeft = _minDuration;
            }
            else
            {
                _movesLeft = _maxDuration;
            }
        }
    }
    #endregion
    
    public sealed override void Use()
    {
        ActivateBuff();
        GameManager.Instance.RoundManager.OnNextRound += TimerReducer;
        GameManager.Instance.RoundManager.OnNextRound += OnMoveAction;
    }

    public sealed override void Unuse()
    {
        MovesLeft = 0;
        GameManager.Instance.RoundManager.OnNextRound -= TimerReducer;
        GameManager.Instance.RoundManager.OnNextRound -= OnMoveAction;
    }

    private void TimerReducer()
    {
        MovesLeft--;
    }
}
