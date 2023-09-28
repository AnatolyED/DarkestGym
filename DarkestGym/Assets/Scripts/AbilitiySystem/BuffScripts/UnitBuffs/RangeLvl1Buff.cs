using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeLvl1Buff : InfinityBuff
{
    public int DistanceToWeak { get; private set; }

    private CellCoordinate _currentPos;
    private float _fullDamage;

    public RangeLvl1Buff(Image image, string name, BaseUnit buffOwner, int distanceToWeak) : base(image, name, buffOwner)
    {
        DistanceToWeak = distanceToWeak;
    }

    protected override void ActivateBuff()
    {
        _fullDamage = BuffOwner.Damage;
        BuffOwner.OnMoveStart += RecalculatePosition;
    }

    protected override void DeactivateBuff()
    {
        BuffOwner.Damage = _fullDamage;
        BuffOwner.OnMoveStart -= RecalculatePosition;
    }

    protected override void OnMoveAction()
    {

    }

    private void RecalculatePosition(Cell arg1, Cell arg2)
    {
        _currentPos = arg2.CellCoordinate;
        BuffLogic();
    }

    private void BuffLogic()
    {
        PlayerNumber enemyNumber = BuffOwner.GetUnitNumber == PlayerNumber.First ? PlayerNumber.Second : PlayerNumber.First;
        List<BaseUnit> enemyUnits = GameManager.Instance.TeamManager.GetUnits(enemyNumber);
        foreach(BaseUnit enemyUnit in enemyUnits)
        {
            Debug.Log(CellCoordinate.Dist(_currentPos, enemyUnit.CurrentCell.CellCoordinate) + " : " + enemyUnit.Name);
            if(CellCoordinate.Dist(_currentPos, enemyUnit.CurrentCell.CellCoordinate) <= DistanceToWeak)
            {
                BuffOwner.Damage = BuffOwner.Damage / 2;
                return;
            }
        }

        // add listener of movement of all units
        BuffOwner.Damage = _fullDamage;
    }
}
