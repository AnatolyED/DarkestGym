using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeLvl1Buff : InfinityBuff
{
    public int DistanceToWeak { get; private set; }

    private float _fullDamage;
    private float _reducedDamage;

    public RangeLvl1Buff(Image image, string name, BaseUnit buffOwner, int distanceToWeak) : base(image, name, buffOwner)
    {
        DistanceToWeak = distanceToWeak;
    }

    protected override void ActivateBuff()
    {
        _fullDamage = BuffOwner.Damage;
        _reducedDamage = BuffOwner.Damage / 2;
        GameManager.Instance.RoundManager.OnUnitStartMove += BuffLogic;
    }

    protected override void DeactivateBuff()
    {
        BuffOwner.Damage = _fullDamage;
        GameManager.Instance.RoundManager.OnUnitStartMove -= BuffLogic;
    }

    protected override void OnMoveAction()
    {

    }

    private void BuffLogic(BaseUnit movedUnit, Cell arg1, Cell arg2)
    {
        PlayerNumber enemyNumber = BuffOwner.GetUnitNumber == PlayerNumber.First ? PlayerNumber.Second : PlayerNumber.First;
        List<BaseUnit> enemyUnits = GameManager.Instance.TeamManager.GetUnits(enemyNumber);
        foreach(BaseUnit enemyUnit in enemyUnits)
        {
            int dist = CellCoordinate.Dist(BuffOwner.CurrentCell.CellCoordinate, enemyUnit.CurrentCell.CellCoordinate);
            if (dist <= DistanceToWeak)
            {
                BuffOwner.Damage = _reducedDamage;
                return;
            }
        }

        BuffOwner.Damage = _fullDamage;   
    }
}
