using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TeamGenerator : MonoBehaviour
{
    public static void GenerateTeam(Player player, List <Transform> position, GameManager gameManager, out TeamList teamList)
    {
        int i = 0;
        Team _generateTeam = player.Team;
        teamList = new TeamList();

        foreach (GameObject unit in _generateTeam.GetTeam)
        {            
            Quaternion _rotation = player.GetPlayerNumber == PlayerNumber.First ? Quaternion.identity : Quaternion.Euler(0, -180, 0);

            GameObject _unit = Instantiate(unit, position[i].position, _rotation, player.gameObject.transform);
            _unit.GetComponent<BaseUnit>().SetGameManager = player.GetGameManager;
            _unit.GetComponent<BaseUnit>().GetUnitNumber = player.GetPlayerNumber;
            position[i] = FindCell(position[i], gameManager);
            position[i].GetComponent<Cell>().GetUnit = _unit;

            if (_unit.TryGetComponent(out BaseUnit baseUnit))
            {
                teamList.AddUnit(baseUnit);
            }

            i++;
        }

    }

    public static Transform FindCell(Transform selectPos, GameManager gameManager) 
    {
        Transform result = default;
        float resultDist = 1f;
        foreach (Transform pos in gameManager._cells)
        {
            float dist = Vector3.Distance(selectPos.position, pos.position);
            if (resultDist>dist)
            {
                result = pos;
            }
        }
        return result;
    }
}
