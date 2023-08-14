using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("������� ��� ������ � �����")]
    [SerializeField] public List<Transform> _cells = new List<Transform>();
    [SerializeField] public List<Transform> _obstacles = new List<Transform>();
    [SerializeField] public List<GameObject> _prefabCell = new List<GameObject>();
    [SerializeField] public List<GameObject> _prefabObstacles = new List<GameObject>();

    [Space,Header("��� ��� ������ � ��������")]
    [SerializeField] private int _points;
    
    [Space,Header("��� ��� ������ � ������� ���������")]
    [SerializeField] private Player _playerOne;
    [SerializeField] private Player _playerTwo;
    [SerializeField] private PlayerNumber _playerTurn;
    [SerializeField] private GameObject _unitThatWallks;
    [SerializeField] private Action _action;

    private void Start()
    {
        _playerTurn = PlayerNumber.First;
    }
    public Player GetFirstPlayer
    {
        get { return _playerOne; }
    }
    public Player GetSecondPlayer
    {
        get { return _playerTwo; }
    }
    public PlayerNumber PlayerTurn
    {
        get { return _playerTurn; }
        set
        {
            if (PlayerNumber.None != value)
            {
                _playerTurn = value;
            }
            else
            {
                Debug.Log("������ �� ����� ����");
            }
        }
    }
    public Action Action
    {
        get { return _action; }
        set
        {
            _action = value;
        }
    }
    public int Points
    {
        get { return _points; }
        set
        {
            if(_unitThatWallks.GetComponent<BaseUnit>()._scriptableObject.GetScorePoint >= value)
            {
                _points = value;
            }
            else
            {
                Debug.Log("�������� �� ����� ���� �����������!");
            }
        }
    }
    public GameObject Unit
    {
        get { return _unitThatWallks; }
        set
        {
            _unitThatWallks = value;
        }
    }

}
