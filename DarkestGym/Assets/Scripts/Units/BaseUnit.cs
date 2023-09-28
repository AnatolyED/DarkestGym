using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BaseUnit : MonoBehaviour
{
    [Header("��������� ���������")]
    [SerializeField] private PlayerNumber _playerNumber;
    [SerializeField] private Action _action;
    [SerializeField] private BaseUnit _target;

    [Header("��������")]
    [SerializeField] private Animator _animator;

    [Header("UI ���������� �����")]
    [SerializeField] private Button[] actionButtons;

    [Header("����������� ���������")]
    [SerializeField] private List<ActiveAbility> _activeAbilitiesList;
    [SerializeField] private List<PassiveAbility> _passiveAbilitiesList;

    [SerializeField] private List<Buttons> actionButtons;

    [Header("������� ��������")]
    [SerializeField] private GameManager _gameManager;
    
    #region ����� ���������
    [Header("���������� � ���������")]
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

    #region ������ � �����������

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
                Debug.Log("�� ��� ���� �����-�� �����");
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
                Debug.Log("�� ��� ���� �����-�� �����");

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
                Debug.Log("�� ��� ���� �����-�� �����");
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
                Debug.Log("�� ��� ���� �����-�� �����");
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
                Debug.Log("�� ��� ���� �����-�� �����");
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
                Debug.Log("�� ��� ���� �����-�� �����");
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
                Debug.Log("�� ��� ���� �����-�� �����");
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
                Debug.Log("�� ��� ���� �����-�� �����");
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
                Debug.Log("�� ��� ���� �����-�� �����");
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
    } //��������� ����� �����������;
    #endregion

    #region State
    private IEnumerator UnitState()
    {
        //�������������� � ���������
        bool completeAction = false;
        Coroutine move = null;
        while (true)
        {
            //��� ������ � ��������
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
                                Debug.Log("���-�� �� �������� ������ ������-�������");
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
                                    target.TakeDamage = Actions.Attack(3, GetComponent<BaseUnit>()); // ����� - �������
                                    Debug.Log(_name + " ����� " + Actions.Attack(4, GetComponent<BaseUnit>()) + " ����� " + target.Name);
                                    _action = Action.Idle;
                                }
                                else
                                {
                                    Debug.Log("������� �*���!");
                                }
                            }
                            else
                            {
                                Debug.Log("����� ��� ���");
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