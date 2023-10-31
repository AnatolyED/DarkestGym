using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Unit", menuName = "UnitBuild/UnitScriptableObject")]
public class Unit : ScriptableObject
{
    [Header("Данные юнита")]
    [SerializeField, Tooltip("Название юнита")] private string _name;
    [SerializeField, Tooltip("Картинка юнита")] private Sprite _sprite;
    [Header("Анимация")]
    [SerializeField,Tooltip("Аниматор юнита")] private Animator _animator;
    [Header("Показатели связанные с действиями")]
    [SerializeField, Tooltip("Название юнита")] private int _speed;
    [SerializeField, Tooltip("Очки для хода")] private int _scorePoint;
    [Header("Показатели связанные со здоровьем")]
    [SerializeField, Tooltip("Здоровье юнита")] private int _health;
    [SerializeField, Tooltip("Кол-во возможного поглощения урона после использования блока")]
    private int _protectionIndicatorHealth;
    [Header("Показатели связанные с атакой")]
    [SerializeField, Tooltip("Показатель атаки")] private int _damage;
    [SerializeField, Tooltip("Множитель урона")] private float _damageMultiplier;
    [SerializeField, Tooltip("Дальность атаки")] private int _range;
    [Header("Показатели связанные с броней")]
    [SerializeField, Tooltip("Показатель брони")] private int _armor;
    [SerializeField, Tooltip("Множитель брони")] private float _armorMultiplier;

    #region Getters
    public string GetName
    {
        get { return _name; }
    }
    public Sprite GetSprite
    {
        get { return _sprite; }
    }
    public int GetSpeed
    {
        get { return _speed; }
    }
    public int GetScorePoint
    {
        get { return _scorePoint; }
    }
    public int GetHealth
    {
        get { return _health; }
    }
    public int GetProtectionIndicatorHealth
    {
        get { return _protectionIndicatorHealth; }
    }
    public int GetDamage
    {
        get { return _damage; }
    }
    public float GetDamageMultiplier
    {
        get { return _damageMultiplier; }
    }
    public int GetRange
    {
        get { return _range; }
    }
    public int GetArmor
    {
        get { return _armor; }
    }
    public float GetArmorMultiplier
    {
        get { return _armorMultiplier; }
    }
    #endregion
}
