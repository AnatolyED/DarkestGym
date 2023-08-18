using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [Header("������� ��� �������������� �� ���� �����")]
    [SerializeField] private GameManager _gameManager;

    [Space, Header("������")]
    [SerializeField] private Button _moveButton;
    [SerializeField] private Button _attackButton;
    [SerializeField] private Button _blockButton;
    [SerializeField] private Button _waitButton;
    [SerializeField] private Button _skillButton;

    [Space, Header("������ � �������� ��� �������� ��������� ������")]
    [SerializeField] private Image _selectedUnit;
    [SerializeField] private GameObject _selectedUnitText;
    [SerializeField] private Image _enemyUnit;
    [SerializeField] private GameObject _enemyUnitText;
}
