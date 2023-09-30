using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for managing battle round actions
/// </summary>
public class RoundManager : MonoBehaviour
{
    /// <summary>
    /// Invokes when turn goes to another player
    /// </summary>
    public event System.Action OnNextRound;

    /// <summary>
    /// Invokes when any unit on map started moving. 
    /// First parameter is the unit, second his previous cell
    /// and third is his next cell.
    /// </summary>
    public event System.Action<BaseUnit, Cell, Cell> OnUnitStartMove;

    private bool _isInit = false;

    public void Init(List<BaseUnit> allUnits)
    {
        foreach (var item in allUnits)
        {
            item.OnMoveStart += (baseUnit, oldCell, newCell) => OnUnitStartMove?.Invoke(baseUnit, oldCell, newCell);
        }

        _isInit = true;
    }
}
