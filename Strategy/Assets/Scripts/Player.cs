using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string _userName = "";
    [SerializeField] private PlayerNumber _playerNumber = PlayerNumber.None;

    [SerializeField] private List<GameObject> _teamPool = new List<GameObject>();

    #region Methods of interaction with the team
    public List<GameObject> GetUnits
    {
        get { return _teamPool; }
    }
    public void AddUnit(List<GameObject> GetUnits)
    {
        foreach (var unit in GetUnits)
        {
            unit.GetComponent<BaseUnit>().GetSetUnitNumber = _playerNumber;
            _teamPool.Add(unit);
        }
    }
    #endregion
}
