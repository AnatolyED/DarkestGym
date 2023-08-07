using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [SerializeField] private Unit _scriptableObject;

    [SerializeField] private IUnitState _currentState;
    Unit unit;
    public BaseUnit()
    {
        _currentState = new IdleState();
    }

    public void SetState(IUnitState newState)
    {
        _currentState = newState;
    }

    public void MoveTo(Vector3 destination)
    {
        //_currentState.Move(this, destination);
    }

    public void Attack(Unit target)
    {
        //_currentState.Attack(this, target);
    }

    public void Block()
    {
        //_currentState.Block(this);
    }

    public void UseAbility()
    {
        //_currentState.UseAbility(this);
    }

    public void Idle()
    {
        //_currentState.Idle(this);
    }
}
