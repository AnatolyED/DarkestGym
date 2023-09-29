using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [Header("Объекты для взаимодействия со всей игрой")]
    [SerializeField] private GameManager _gameManager;

    [Space, Header("Кнопки")]
    [SerializeField] private Button _moveButton;
    [SerializeField] private Button _attackButton;
    [SerializeField] private Button _blockButton;
    [SerializeField] private Button _waitButton;
    [SerializeField] private Button _skillButton;

    [Space, Header("Иконки и здоровье для спрайтов выбранных юнитов")]
    [SerializeField] private Image _selectedUnit;
    [SerializeField] private GameObject _selectedUnitText;
    [SerializeField] private Image _enemyUnit;
    [SerializeField] private GameObject _enemyUnitText;

    #region События на нажатие кнопок
    #endregion
}
