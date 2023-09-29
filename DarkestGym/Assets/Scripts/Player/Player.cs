using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�������� �������������� � ������ �����������
    [Header("������� ����� ��� ��������������")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerNumber _playerNumber;

    //�������
    [Header("��������� ������")]
    [SerializeField] private Team _team;

    public PlayerNumber GetPlayerNumber
    {
        get { return _playerNumber; }
    }
    public Team Team
    {
        get { return _team; }
        set { _team = value; }
    }
    public GameManager GetGameManager
    {
        get { return _gameManager; }
    }
    
}
