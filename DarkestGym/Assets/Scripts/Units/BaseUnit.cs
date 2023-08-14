using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUnit : MonoBehaviour
{
    [Header("��������� ���������")]
    [SerializeField] private PlayerNumber _playerNumber;
    [SerializeField] private Action action;
    [SerializeField] private BaseUnit target;

    [Header("��������")]
    [SerializeField] private Animator animator;

    [Header("UI ���������� �����")]
    [SerializeField] private Button[] actionButtons;
    
    #region ����� ���������
    [Header("���������� � ���������")]
    [SerializeField] public Unit _scriptableObject;
    [SerializeField] private string _name;
    [SerializeField] private int _speed;
    [SerializeField] private int _scorePoint;
    [SerializeField] private float _health;
    [SerializeField] private float _protectionIndicatorHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private int _range;
    [SerializeField] private float _armor;
    [SerializeField] private float _armorMultiplier;
    [SerializeField] private List<AbilityName> _abilityList;
    #endregion

    private void Start()
    {
        action = Action.Idle;
        _name = _scriptableObject.GetName;
        Speed = _scriptableObject.GetSpeed;
        ScorePoint = _scriptableObject.GetScorePoint;
        Health = _scriptableObject.GetHealth;
        ProtectionIndicatorHealth = _scriptableObject.GetProtectionIndicatorHealth;
        Damage = _scriptableObject.GetDamage;
        DamageMultiplier = _scriptableObject.GetDamageMultiplier;
        Armor = _scriptableObject.GetArmor;
        ArmorMultiplier = _scriptableObject.GetArmorMultiplier;
        AbilityList = _scriptableObject.UnitAbility;
        StartCoroutine(UnitState());
    }

    #region ������ � �����������
    public string Name
    {
        get { return _name; }
        set
        {
            if (_scriptableObject.name == value)
            {
                _name = value;
            }
            else
            {
                Debug.Log("�� ��� ���� �����-�� �����");
            }
        }
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
    public List<AbilityName> AbilityList
    {
        get { return _abilityList; }
        set
        {
            if (_scriptableObject.UnitAbility == value)
            {
                _abilityList = value;
            }
            else
            {
                Debug.Log("���-�� ������");
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
    #endregion

    #region State
    private IEnumerator UnitState()
    {
        while (true)
        {
            switch (action)
            {
                case Action.Idle:
                    break;
                case Action.Move:
                    break;
                case Action.Attack:
                    
                    break;
                case Action.Block:
                    ProtectionIndicatorHealth += Actions.Block(ScorePoint,Armor,ArmorMultiplier);
                    action = Action.Idle;
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
}