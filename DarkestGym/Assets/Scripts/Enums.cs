using UnityEngine;

public enum AbilityName
{
    //�������
    [Tooltip("��������� � ������")] ContempForTheWeak,
    [Tooltip("������� ��� �� �����")]  ItIsNoLongerFashionableToDestroy,
    [Tooltip("������������ � ������")] ContemotForTheWeak,
    //FeiChao
    [Tooltip("������������ ���")] ImprovingActing,
    //Linnet
    [Tooltip("��� ������ � ������� ���")] NoMeleePenalty,
    [Tooltip("����� �������")] ChangingPositions,
    //Tank
    [Tooltip("��������� ����� � ������� ���")] ReflectionOfMeleeDamage,
    //Range
    [Tooltip("�������� � ������� ���")] WeaknessInCloseCombat
}

public enum PlayerNumber
{
    None,
    First,
    Second
}

public enum Action
{
    Idle,
    Move,
    Attack,
    Block,
    Ability,
    EndMove
}