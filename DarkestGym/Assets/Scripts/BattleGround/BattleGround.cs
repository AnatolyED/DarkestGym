using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGround : MonoBehaviour
{
    [SerializeField] private List<Cell> _battleGroundCells;

    public List<Cell> BattleGroundCells
    {
        get
        {
            if(_battleGroundCells == null && _battleGroundCells.Count == 0) 
            {
                Debug.LogError("There is no BattleGrounds cells have been chosen");
                return null;
            }
            return new List<Cell>(_battleGroundCells);
        }
    }
}
