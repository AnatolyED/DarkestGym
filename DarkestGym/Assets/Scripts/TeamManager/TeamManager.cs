using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TeamManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private TeamList _teamListPlayer1 = null;
    private TeamList _teamListPlayer2 = null;

    private bool _isInit = false;

    public void Init(TeamList tl1, TeamList tl2)
    {
        if(!_isInit)
        {
            _teamListPlayer1 = tl1;
            _teamListPlayer2 = tl2;
            _isInit = true;
        }
        else
        {
            Debug.LogError("Teams have been already initialized");
        }
    }

    public List<BaseUnit> GetUnits(PlayerNumber playerNumber)
    {
        if(!_isInit)
        {
            Debug.LogError("TeamManager is not init");
            return null;
        }

        switch (playerNumber)
        {
            case PlayerNumber.First:
                return _teamListPlayer1.GetTeamList();
            case PlayerNumber.Second:
                return _teamListPlayer2.GetTeamList();
            default:
                Debug.LogError("Invalid playerNumber");
                return null;
        }
    }

    public List<BaseUnit> GetAllUnits()
    {
        if (!_isInit)
        {
            Debug.LogError("TeamManager is not init");
            return null;
        }

        return _teamListPlayer1.GetTeamList().Concat(_teamListPlayer2.GetTeamList()).ToList();
    }
}
