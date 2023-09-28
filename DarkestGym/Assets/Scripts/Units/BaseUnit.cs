using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BaseUnit : MonoBehaviour
{
    [Header("Состояние персонажа")]
    [SerializeField] private PlayerNumber _playerNumber;
    [SerializeField] private Action _action;
    [SerializeField] private BaseUnit _target;

    [Header("Анимация")]
    [SerializeField] private Animator _animator;

    [Header("UI компоненты юнита")]
    [SerializeField] private Button[] actionButtons;

    [Header("Способности персонажа")]
    [SerializeField] private List<ActiveAbility> _activeAbilitiesList;
    [SerializeField] private List<PassiveAbility> _passiveAbilitiesList;

    [SerializeField] private List<Buttons> actionButtons;

    [Header("Игровой менеджер")]
    [SerializeField] private GameManager _gameManager;
    
    #region Статы персонажа
    [Header("Информация о персонаже")]
    [SerializeField] public Unit _scriptableObject;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _speed;
    [SerializeField] private int _scorePoint;
    [SerializeField] private float _health;
    [SerializeField] private float _protectionIndicatorHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private int _range;
    [SerializeField] private float _armor;
    [SerializeField] private float _armorMultiplier;
    #endregion

    private BuffManager _buffManager;
    public BuffManager BuffManager => _buffManager;

    private void Awake()
    {
        if(_buffManager != null)
        {
            Debug.LogError("Buff manager is not null on Awake method");
        }
        if(TryGetComponent(out BuffManager buffManager))
        {
            _buffManager = buffManager;
        }
        else
        {
            Debug.LogError("There is no BuffManager on baseUnit object");
        }

        _action = Action.Idle;
        Name = _scriptableObject.GetName;
        Sprite = _scriptableObject.GetSprite;
        Speed = _scriptableObject.GetSpeed;
        ScorePoint = _scriptableObject.GetScorePoint;
        Health = _scriptableObject.GetHealth;
        ProtectionIndicatorHealth = _scriptableObject.GetProtectionIndicatorHealth;
        Damage = _scriptableObject.GetDamage;
        DamageMultiplier = _scriptableObject.GetDamageMultiplier;
        Range = _scriptableObject.GetRange;
        Armor = _scriptableObject.GetArmor;
        ArmorMultiplier = _scriptableObject.GetArmorMultiplier;
        _activeAbilitiesList = _scriptableObject.GetActiveAbilitiesList.Select((aad) => {  return aad.GetAbility(this); }).ToList();
        _passiveAbilitiesList = _scriptableObject.GetPassiveAbilitiesList.Select((pad) => {  return pad.GetAbility(this); }).ToList();
    }

    private void Start()
    {
        StartCoroutine(UnitState());
    }

    #region Работа с параметрами

    public GameManager SetGameManager
    {
        set { _gameManager = value; }
    }
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
        }
    }
    public Sprite Sprite
    {
        get { return _sprite; }
        set
        {
            if(_scriptableObject.GetSprite == value)
            {
                _sprite = value;
            }
        }
    }
    public Animator Animator
    {
        get { return _animator;}
    }
    public int Speed
    {
        get { return _speed; }
        set
        {
            if (_scriptableObject.GetSpeed >= value)
            {
                _speed = value;
            }
            else
            {
                Debug.Log("Ну тут явно какой-то обман");
            }
        }
    }
    public int ScorePoint
    {
        get { return _scorePoint; }
        set
        {
            if (_scriptableObject.GetScorePoint >= value)
            {
                _scorePoint = value;
            }
            else
            {
                Debug.Log("Ну тут явно какой-то обман");

            }
        }
    }
    public float Health
    {
        get { return _health; }
        set
        {
            if (_scriptableObject.GetHealth >= value)
            {
                _health = value;
                if (_health <= 0)
                {

                }
            }
            else
            {
                Debug.Log("Ну тут явно какой-то обман");
            }
        }
    }
    public float ProtectionIndicatorHealth
    {
        get { return _protectionIndicatorHealth; }
        set
        {
            if ((_scriptableObject.GetArmor * (_scriptableObject.GetArmorMultiplier * _scriptableObject.GetScorePoint)) >= value)
            {
                _protectionIndicatorHealth = value;
            }
            else
            {
                Debug.Log("Ну тут явно какой-то обман");
            }
        }
    }
    public float Damage
    {
        get { return _damage; }
        set
        {
            if ((_scriptableObject.GetDamage * (_scriptableObject.GetDamageMultiplier * _scriptableObject.GetScorePoint)) >= value)
            {
                _damage = value;
            }
            else
            {
                Debug.Log("Ну тут явно какой-то обман");
            }
        }
    }
    public float DamageMultiplier
    {
        get { return _damageMultiplier; }
        set
        {
            if (_scriptableObject.GetDamageMultiplier >= value)
            {
                _damageMultiplier = value;
            }
            else
            {
                Debug.Log("Ну тут явно какой-то обман");
            }
        }
    }
    public int Range
    {
        get { return _range; }
        set
        {
            if(_scriptableObject.GetRange >= value)
            {
                _range = value;
            }
            else
            {
                Debug.Log("Ну тут явно какой-то обман");
            }
        }
    }
    public float Armor
    {
        get { return _armor; }
        set
        {
            if (_scriptableObject.GetArmor >= value)
            {
                _armor = value;
            }
            else
            {
                Debug.Log("Ну тут явно какой-то обман");
            }
        }
    }
    public float ArmorMultiplier
    {
        get { return _armorMultiplier; }
        set
        {
            if (_scriptableObject.GetArmorMultiplier >= value)
            {
                _armorMultiplier = value;
            }
            else
            {
                Debug.Log("Ну тут явно какой-то обман");
            }
        }
    }
    public PlayerNumber GetUnitNumber
    {
        get { 
            return _playerNumber;
        }
        set
        {
            _playerNumber = value;
        }
    }
    public float TakeDamage
    {
        set 
        { 
            _health -= value;
            if (_health <= 0) 
            {
                Die();
            }
        }
    } //Получения урона персонажами;
    #endregion

    #region State
    private IEnumerator UnitState()
    {
        //Взаимодействие с корутиной
        bool completeAction = false;
        Coroutine move = null;
        while (true)
        {
            //Для работы с клетками
            Cell newCell = null;
            BaseUnit target = null;
            Vector3 mousePosition = Input.mousePosition;

            switch (_action)
            {
                case Action.Idle:
                    break;
                case Action.Move:
                    if (Input.GetMouseButtonDown(0) && move == null)
                    {
                        Ray ray = _gameManager.GetGamera.ScreenPointToRay(mousePosition);
                        if (Physics.Raycast(ray, out RaycastHit hit))
                        {
                            if (hit.transform.gameObject.GetComponent<Cell>() != null && hit.transform.gameObject.GetComponent<Cell>().GetUnit == null)
                            {
                                newCell = hit.transform.gameObject.GetComponent<Cell>();
                                if (newCell != null && move == null)
                                {
                                    move = StartCoroutine(Actions.Move(this.gameObject, newCell, completeAction));
                                }
                            }
                            else
                            {
                                Debug.Log("Где-то ты допустил ошибку дружок-пиражок");
                            }
                        }

                    } else if(completeAction == false)
                    { 

                    }
                    else if(completeAction == true)
                    {
                        if (completeAction != false) 
                        {
                            if (move != null)
                            {
                                StopCoroutine(move);
                                move = null;
                            }
                            completeAction = false;
                        }
                        _action = Action.Idle;
                    }
                    break;
                case Action.Attack:
                    if (Input.GetMouseButtonDown(0))
                    {
                        Ray ray = _gameManager.GetGamera.ScreenPointToRay(mousePosition);
                        if (Physics.Raycast(ray, out RaycastHit hit))
                        {
                            if (hit.transform.gameObject.GetComponent<Cell>() != null && hit.transform.gameObject.GetComponent<Cell>().GetUnit != null)
                            {
                                target = hit.transform.gameObject.GetComponent<Cell>().GetUnit.GetComponent<BaseUnit>();

                                if (this.GetUnitNumber != target.GetUnitNumber)
                                {
                                    target.TakeDamage = Actions.Attack(3, GetComponent<BaseUnit>()); // цифра - затычка
                                    Debug.Log(_name + " нанес " + Actions.Attack(4, GetComponent<BaseUnit>()) + " урона " + target.Name);
                                    _action = Action.Idle;
                                }
                                else
                                {
                                    Debug.Log("Союзник е*лан!");
                                }
                            }
                            else
                            {
                                Debug.Log("Врага тут нет");
                            }
                        }
                    }
                    break;
                case Action.Block:
                    ProtectionIndicatorHealth += Actions.Block(3,Armor,ArmorMultiplier);
                    _action = Action.Idle;
                    break;
                case Action.Ability:
                    break;
                case Action.EndMove:
                    break;
                default:
                    break;
            }
            yield return null;
        }
    }
    #endregion

    private void Die()
    {
        Destroy(gameObject);
    }
}