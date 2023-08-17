using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        _action = Action.Idle;
        Name = _scriptableObject.GetName;
        Sprite = _scriptableObject.GetSprite;
        Speed = _scriptableObject.GetSpeed;
        ScorePoint = _scriptableObject.GetScorePoint;
        Health = _scriptableObject.GetHealth;
        ProtectionIndicatorHealth = _scriptableObject.GetProtectionIndicatorHealth;
        Damage = _scriptableObject.GetDamage;
        DamageMultiplier = _scriptableObject.GetDamageMultiplier;
        Armor = _scriptableObject.GetArmor;
        ArmorMultiplier = _scriptableObject.GetArmorMultiplier;
        StartCoroutine(UnitState());
    }

    #region Работа с параметрами
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
                Debug.Log("Ну тут явно какой-то обман");
            }
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
    #endregion

    #region State
    private IEnumerator UnitState()
    {
        while (true)
        {
            switch (_action)
            {
                case Action.Idle:
                    break;
                case Action.Move:
                    break;
                case Action.Attack:
                    
                    break;
                case Action.Block:
                    ProtectionIndicatorHealth += Actions.Block(ScorePoint,Armor,ArmorMultiplier);
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
}