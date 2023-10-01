using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// GameManager instance property that is realizing Singleton pattern
    /// </summary>
    public static GameManager Instance { get; private set; }

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

    /// <summary>
    /// Instance of RoundManager 
    /// </summary>
    public RoundManager RoundManager { get; private set; }

    public TeamManager TeamManager { get; private set; }

    //Игровая камера и компоненты к ней
    [SerializeField] private Camera _mainCamera;

    [SerializeField] private GameObject _canvasObject;
    public GameObject CanvasObject => _canvasObject;

    [SerializeField] private Button _activeAbilityBtnPrefab;
    public Button ActiveAbilityBtnPrefab => _activeAbilityBtnPrefab;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("GameManager Instance does not equal null on Awake method");
        }
        Instance = this;

        if(RoundManager != null)
        {
            Debug.LogError("RoundManager does not equal null on Awake method");
        }
        if(TryGetComponent(out RoundManager roundManager))
        {
            RoundManager = roundManager;
        }
        else
        {
            Debug.LogError("RoundManager have not been found on GameManager object");
        }

        if (TeamManager != null)
        {
            Debug.LogError("TeamManager does not equal null on Awake method");
        }
        if (TryGetComponent(out TeamManager teamManager))
        {
            TeamManager = teamManager;
        }
        else
        {
            Debug.LogError("TeamManager have not been found on GameManager object");
        }

        _mainCamera = Camera.main;
    }

    private void Start()
    {
        _firstPlayerUnitsPrefabPull = _playerOne.Team;
        TeamList tl1;
        TeamList tl2;

        if (_firstPlayerUnitsPrefabPull != null)
        {
            TeamGenerator.GenerateTeam(_playerOne, _firstPlayerUnitPosition, GetComponent<GameManager>(), out tl1);

        }
        else
        {
            int TeamNumber = Random.Range(0, _teamPrefabs.Count);
            _playerOne.Team =_teamPrefabs[TeamNumber];
            TeamGenerator.GenerateTeam(_playerOne, _firstPlayerUnitPosition, GetComponent<GameManager>(), out tl1);
        }

        _secondPlayerUnitsPrefabPull = _playerTwo.Team;
        if (_secondPlayerUnitsPrefabPull != null)
        {
            TeamGenerator.GenerateTeam(_playerTwo, _secondPlayerUnitPosition, GetComponent<GameManager>(), out tl2);
        }
        else
        {
            int TeamNumber = Random.Range(0, _teamPrefabs.Count);
            _playerTwo.Team = _teamPrefabs[TeamNumber];
            TeamGenerator.GenerateTeam(_playerTwo, _secondPlayerUnitPosition,GetComponent<GameManager>(), out tl2);
        }

        TeamManager.Init(tl1, tl2);

        TeamManager.GetAllUnits().ForEach(unit => {
            unit.ApplyPassiveAbilities();
        });

        RoundManager.Init(TeamManager.GetAllUnits());

        TargetSelector mainSelector = new TargetSelector();
        mainSelector.OnTargetSelected += (unit) =>
        {
            Debug.Log(unit.Name);
            unit.ShowActiveAbilitiesButtons();
        };

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
