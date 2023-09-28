using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamList
{
    private List<BaseUnit> _teamList = new List<BaseUnit>();

    public TeamList(List<BaseUnit> teamList)
    {
        foreach (var item in teamList) { _teamList.Add(item); }
    }

    public TeamList() { }

    public List<BaseUnit> GetTeamList()
    {
        List<BaseUnit> _newTeamlist = new List<BaseUnit>();
        foreach (var item in _teamList) { _newTeamlist.Add(item); }
        return _newTeamlist;
    }

    public void AddUnit(BaseUnit unit)
    {
        _teamList.Add(unit);
    }
}
