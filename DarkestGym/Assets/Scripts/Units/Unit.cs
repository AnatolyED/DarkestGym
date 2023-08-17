using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObject/UnitScriptableObject")]
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
    [SerializeField, Tooltip("Здоровье юнита")] private float _health;
    [SerializeField, Tooltip("Кол-во возможного поглощения урона после использования блока")]
    private float _protectionIndicatorHealth;
    [Header("Показатели связанные с атакой")]
    [SerializeField, Tooltip("Показатель атаки")] private float _damage;
    [SerializeField, Tooltip("Множитель урона")] private float _damageMultiplier;
    [SerializeField, Tooltip("Дальность атаки")] private int _range;
    [Header("Показатели связанные с броней")]
    [SerializeField, Tooltip("Показатель брони")] private float _armor;
    [SerializeField, Tooltip("Множитель брони")] private float _armorMultiplier;

    #region Гетеры
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
    public float GetHealth
    {
        get { return _health; }
    }
    public float GetProtectionIndicatorHealth
    {
        get { return _protectionIndicatorHealth; }
    }
    public float GetDamage
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
    public float GetArmor
    {
        get { return _armor; }
    }
    public float GetArmorMultiplier
    {
        get { return _armorMultiplier; }
    }
    #endregion
}
