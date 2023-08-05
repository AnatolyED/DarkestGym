using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObject/Unit")]
public class Unit : ScriptableObject
{
    [SerializeField] private string _name;
}
