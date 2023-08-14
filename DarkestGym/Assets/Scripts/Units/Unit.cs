using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObject/UnitScriptableObject")]
public class Unit : ScriptableObject
{
    [Header("������ �����")]
    [SerializeField, Tooltip("�������� �����")] private string _name;
    [Header("���������� ��������� � ����������")]
    [SerializeField, Tooltip("�������� �����")] private int _speed;
    [SerializeField, Tooltip("���� ��� ����")] private int _scorePoint;
    [Header("���������� ��������� �� ���������")]
    [SerializeField, Tooltip("�������� �����")] private float _health;
    [SerializeField, Tooltip("���-�� ���������� ���������� ����� ����� ������������� �����")]
    private float _protectionIndicatorHealth;
    [Header("���������� ��������� � ������")]
    [SerializeField, Tooltip("���������� �����")] private float _damage;
    [SerializeField, Tooltip("��������� �����")] private float _damageMultiplier;
    [SerializeField, Tooltip("��������� �����")] private int _range;
    [Header("���������� ��������� � ������")]
    [SerializeField, Tooltip("���������� �����")] private float _armor;
    [SerializeField, Tooltip("��������� �����")] private float _armorMultiplier;
    [Header("����������� ���������")] 
    [SerializeField,Tooltip("����������� ���������")]private List<AbilityName> _unitAbility;

    public string GetName
    {
        get { return _name; }
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
    public List<AbilityName> UnitAbility
    {
        get { return _unitAbility; }
    }
}
