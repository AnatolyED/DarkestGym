using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Добавить взаимодействие с личным интерфейсом
    [Header("Объекты сцены для взаимодействия")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerNumber _playerNumber;

    //команда
    [Header("Параметры игрока")]
    [SerializeField] private Team _team;
    public PlayerNumber GetPlayerNumber
    {
        get { return _playerNumber; }
    }

    [SerializeField] private List<GameObject> _unitList = new List<GameObject>(6);
    
}
