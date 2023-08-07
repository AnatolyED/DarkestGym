using UnityEngine;

public interface IUnitState
{
    void Move(Unit unit, Vector3 destination);
    void Attack(Unit unit, Unit target);
    void Block(Unit unit);
    void UseAbility(Unit unit);
    void Idle(GameObject unit);
}
