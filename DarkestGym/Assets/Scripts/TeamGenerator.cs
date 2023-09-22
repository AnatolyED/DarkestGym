using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TeamGenerator : MonoBehaviour
{
    public static void GenerateTeam(Player player, List <Transform> position, GameManager gameManager)
    {
        int i = 0;
        Team _generateTeam = player.Team;

        foreach (GameObject unit in _generateTeam.GetTeam)
        {
            #region Test
            /*
                Debug.Log(unit.GetComponent<BaseUnit>()._scriptableObject.GetName);
                Debug.Log(unit.GetComponent<BaseUnit>()._scriptableObject.GetHealth);
            */
            #endregion

            GameObject _unit = Instantiate(unit, position[i].position,Quaternion.identity, player.gameObject.transform);

            position[i] = FindCell(position[i],gameManager);
            position[i].GetComponent<Cell>().GetUnit = _unit;
            
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
