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
            #region Test
            /*
                Debug.Log(unit.GetComponent<BaseUnit>()._scriptableObject.GetName);
                Debug.Log(unit.GetComponent<BaseUnit>()._scriptableObject.GetHealth);
            */
            #endregion
            
            Quaternion _rotation = player.GetPlayerNumber == PlayerNumber.First ? Quaternion.identity : Quaternion.Euler(0, -180, 0);

            GameObject _unit = Instantiate(unit, position[i].position, _rotation, player.gameObject.transform);
            BaseUnit baseUnit;
            if(!_unit.TryGetComponent(out baseUnit))
            {
                Debug.LogError("Base unit has not been found on this object");
            }

            baseUnit.SetGameManager = player.GetGameManager;
            baseUnit.GetUnitNumber = player.GetPlayerNumber;
            position[i] = FindCell(position[i], gameManager);
            baseUnit.CurrentCell = position[i].GetComponent<Cell>();
            position[i].GetComponent<Cell>().GetUnit = _unit;
            teamList.AddUnit(baseUnit);
            
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
