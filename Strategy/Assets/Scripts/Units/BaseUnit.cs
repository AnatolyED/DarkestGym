using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [Header("ScriptableObject для персонажа")]
    [SerializeField] private Unit _unitScriptableObject;

    [Header("Компоненты персонажа")]
    [SerializeField] private Sprite _unitSprite = null;
    [SerializeField] private Animator _unitAnimator = null;
    [SerializeField, Tooltip("Принадлежность к команде")] private PlayerNumber _unitTeam = PlayerNumber.None;

    [Header("Параметры персонажа")]
    [SerializeField] private string _name = "";
    [SerializeField] private int _health = 0;
    [SerializeField] private int _protectionHealth = 0;
    [SerializeField] private int _armor = 0;
    [SerializeField] private float _armorMultiplyer = 0;
    [SerializeField] private int _damage = 0;
    [SerializeField] private float _damageMultiplier = 0;
    [SerializeField] private int _attackRange = 0;
    [SerializeField] private int _speed = 0;
    [SerializeField] private int _scorePoint = 0;
    [SerializeField] private int _bonusScorePoint = 0;

    private void Start()
    {
        InitializingParameters();
    }

    #region Initialization Parameters and Getters/Setters
    private void InitializingParameters()
    {
        _unitSprite = _unitScriptableObject.GetSprite;
        _unitAnimator = GetComponent<Animator>();
        _name = _unitScriptableObject.name;
        _health = _unitScriptableObject.GetHealth;
        _protectionHealth = _unitScriptableObject.GetProtectionIndicatorHealth;
        _armor = _unitScriptableObject.GetArmor;
        _armorMultiplyer = _unitScriptableObject.GetArmorMultiplier;
        _damage = _unitScriptableObject.GetDamage;
        _damageMultiplier = _unitScriptableObject.GetDamageMultiplier;
        _attackRange = _unitScriptableObject.GetRange;
        _speed = _unitScriptableObject.GetSpeed;
        _scorePoint = _unitScriptableObject.GetScorePoint;
    }
    public void ReturnBaseScorePoint()
    {
        _scorePoint = _unitScriptableObject.GetScorePoint + _bonusScorePoint;
    }
    public PlayerNumber GetSetUnitNumber
    {
        get { return _unitTeam; }
        set { _unitTeam = value; }
    }
    public int GetSetHealth
    {
        get { return _health; }
        set
        {
            if ((_health + value) <= 0)
            {
                _health += value;
                Invoke(nameof(Death), 2f);
            }
            else
            {
                _health += value;
            }
        }
    }
    public int GetSetProtectionHealth
    {
        get { return _protectionHealth; }
        set { _protectionHealth += value; }
    }
    public int GetSetArmor
    {
        get { return _armor; }
        set { _armor += value; }
    }
    public float GetSetArmorMultiplyer
    {
        get { return _armorMultiplyer; }
        set{ _armorMultiplyer += value; }
    }
    public int GetSetDamage
    {
        get { return _damage; }
        set { _damage += value; }
    }
    public float GetSetDamageMultiplyer
    {
        get { return _damageMultiplier; }
        set { _damageMultiplier += value; }
    }
    public int GetSetAttackRange
    {
        get { return _attackRange; }
        set { _attackRange += value; }
    }
    public int GetSetSpeed
    {
        get { return _speed; }
        set { _speed += value; }
    }
    public int GetSetScorePoint
    {
        get { return _scorePoint; }
        set { _scorePoint += value; }
    }
    #endregion

    private void Death()
    {
        Destroy(gameObject);
    }
}
