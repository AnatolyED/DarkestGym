using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [Header("Информация о персонаже")]
    [SerializeField] private Unit _scriptableObject;
    [SerializeField] private string _name;
    [SerializeField] private int _speed;
    [SerializeField] private int _scorePoint;
    [SerializeField] private float _health;
    [SerializeField] private float _protectionIndicatorHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _damageMultiplier;
    [SerializeField] private float _armor;
    [SerializeField] private float _armorMultiplier;

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
            if(_scriptableObject.GetDamageMultiplier >= value)
            {
                _damageMultiplier = value;
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
            if (_scriptableObject.GetArmor >= _armor)
            {
                _armorMultiplier = value;
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
            if (_scriptableObject.GetArmorMultiplier >= _armorMultiplier)
            {
                _armorMultiplier = value;
            }
            else
            {
                Debug.Log("Ну тут явно какой-то обман");
            }
        }
    }

    private void Start()
    {
        _name = _scriptableObject.GetName;
        Speed = _scriptableObject.GetSpeed;
        ScorePoint = _scriptableObject.GetScorePoint;
        Health = _scriptableObject.GetHealth;
        ProtectionIndicatorHealth = _scriptableObject.GetProtectionIndicatorHealth;
        Damage = _scriptableObject.GetDamage;
        DamageMultiplier = _scriptableObject.GetDamageMultiplier;
        Armor = _scriptableObject.GetArmor;
        ArmorMultiplier = _scriptableObject.GetArmorMultiplier;
    }
}
