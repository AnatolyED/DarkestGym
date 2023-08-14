using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Добавить взаимодействие с личным интерфейсом
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerNumber _playerNumber;
    public PlayerNumber GetPlayerNumber
    {
        get { return _playerNumber; }
    }

    [SerializeField] private List<GameObject> _unitList = new List<GameObject>();
    
}
