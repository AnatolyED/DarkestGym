using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Все дря работы с игровым процессом")]
    [SerializeField] private PlayerNumber _playerTurn;
    [SerializeField] private GameObject _activeUnit;
    [SerializeField] private Action _action;

    [Space, Header("Игроки")]
    [SerializeField] private Player _playerOne;
    [SerializeField] private Player _playerTwo;

    [Space, Header("Объекты для работы с полем")]
    [SerializeField] public List<Transform> _cells = new List<Transform>();
    [SerializeField] public List<Transform> _waterObstaclesCells = new List<Transform>();
    [SerializeField] public List<Transform> _obstacles = new List<Transform>();
    [SerializeField] public List<GameObject> _prefabCell = new List<GameObject>();
    [SerializeField] public List<GameObject> _waterpObstaclesPrefab = new List<GameObject>();
    [SerializeField] public List<GameObject> _prefabObstacles = new List<GameObject>();

    [Space, Header("Объекты для работы с генерацией команды")]
    [SerializeField] private List<Team> _teamPrefabs = new List<Team>();

    [SerializeField] private Team _firstPlayerUnitsPrefabPull;
    [SerializeField] private List<Transform> _firstPlayerUnitPosition;

    [SerializeField] private Team _secondPlayerUnitsPrefabPull;
    [SerializeField] private List<Transform> _secondPlayerUnitPosition;

    [Space, Header("Все для работы с клетками")]
    [SerializeField] private int _points;
    //Игровая камера и компоненты к ней
    [SerializeField] private Camera _mainCamera;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        _firstPlayerUnitsPrefabPull = _playerOne.Team;
        if (_firstPlayerUnitsPrefabPull != null)
        {
            TeamGenerator.GenerateTeam(_playerOne, _firstPlayerUnitPosition, GetComponent<GameManager>());
        }
        else
        {
            int TeamNumber = Random.Range(0, _teamPrefabs.Count);
            _playerOne.Team =_teamPrefabs[TeamNumber];
            TeamGenerator.GenerateTeam(_playerOne, _firstPlayerUnitPosition, GetComponent<GameManager>());
        }

        _secondPlayerUnitsPrefabPull = _playerTwo.Team;
        if (_secondPlayerUnitsPrefabPull != null)
        {
            TeamGenerator.GenerateTeam(_playerTwo, _secondPlayerUnitPosition, GetComponent<GameManager>());
        }
        else
        {
            int TeamNumber = Random.Range(0, _teamPrefabs.Count);
            _playerTwo.Team = _teamPrefabs[TeamNumber];
            TeamGenerator.GenerateTeam(_playerTwo, _secondPlayerUnitPosition,GetComponent<GameManager>());
        }

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
                Debug.Log("Такого не может быть");
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
            if(_activeUnit.GetComponent<BaseUnit>()._scriptableObject.GetScorePoint >= value)
            {
                _points = value;
            }
            else
            {
                Debug.Log("Операция не может быть произведена!");
            }
        }
    }
    public GameObject Unit
    {
        get { return _activeUnit; }
        set
        {
            _activeUnit = value;
        }
    }
    public Camera GetGamera
    {
        get { return _mainCamera; }
    }
    
}
