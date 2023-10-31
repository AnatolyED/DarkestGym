using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("���������")]
    [SerializeField] private RoundManager RoundManager;
    [SerializeField] private UnitActionManager UnitActionManager;

    [Header("��������")]
    [SerializeField] private Coroutine RoundManagerCorutine = null;

    [Header("������")]
    [SerializeField] private Player _firstPlayer;
    [SerializeField] private Player _secondPlayer;

    [Header("������� ����")]
    [SerializeField] private List<GameObject> _fieldCells = new List<GameObject>();
    [SerializeField] private List<GameObject> _obstacles = new List<GameObject>();
    [SerializeField] private List<GameObject> _backendObstacles = new List<GameObject>();

    private void Start()
    {
        FieldMapGenerator FieldMap = FieldMapGenerator.GetInstance();
        FieldMap.MapGenerator(_fieldCells, out _fieldCells, _obstacles, out _obstacles, _backendObstacles, out _backendObstacles, RoundManager);
        RoundManager.SortingUnitsAtTheStart(_firstPlayer,_secondPlayer,out RoundManagerCorutine);
        
    }

    #region Transfer methods
    public void TransferOfTheRoundManagerUnit(GameObject unit)
    {
        UnitActionManager.GetSetUnit = unit;
    }
    #endregion
}
