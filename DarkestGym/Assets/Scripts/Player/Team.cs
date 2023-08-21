using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "TeamBuild/Team")]

public class Team : ScriptableObject
{
    [SerializeField,Range(1,6)] private List<GameObject> _unitList = new List<GameObject>(6);
    public List<GameObject> GetTeam
    {
        get { return _unitList; }
    }
}
