using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "Unit", menuName = "UnitBuild/UnitScriptableObject")]
public class Unit : ScriptableObject
{
    [Header("������ �����")]
    [SerializeField, Tooltip("�������� �����")] private string _name;
    [SerializeField, Tooltip("�������� �����")] private Sprite _sprite;
    [Header("��������")]
    [SerializeField,Tooltip("�������� �����")] private Animator _animator;
    [Header("���������� ��������� � ����������")]
    [SerializeField, Tooltip("�������� �����")] private int _speed;
    [SerializeField, Tooltip("���� ��� ����")] private int _scorePoint;
    [Header("���������� ��������� �� ���������")]
    [SerializeField, Tooltip("�������� �����")] private int _health;
    [SerializeField, Tooltip("���-�� ���������� ���������� ����� ����� ������������� �����")]
    private int _protectionIndicatorHealth;
    [Header("���������� ��������� � ������")]
    [SerializeField, Tooltip("���������� �����")] private int _damage;
    [SerializeField, Tooltip("��������� �����")] private float _damageMultiplier;
    [SerializeField, Tooltip("��������� �����")] private int _range;
    [Header("���������� ��������� � ������")]
    [SerializeField, Tooltip("���������� �����")] private int _armor;
    [SerializeField, Tooltip("��������� �����")] private float _armorMultiplier;

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
