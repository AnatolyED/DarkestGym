using UnityEngine;

public class IdleState : IUnitState
{
    public void Attack(Unit unit, Unit target)
    {
        throw new System.NotImplementedException();
    }

    public void Block(Unit unit)
    {
        throw new System.NotImplementedException();
    }

    public void Idle(GameObject unit)
    {
        throw new System.NotImplementedException();
    }

    public void Move(Unit unit, Vector3 destination)
    {
        throw new System.NotImplementedException();
    }

    public void UseAbility(Unit unit)
    {
        throw new System.NotImplementedException();
    }
}
