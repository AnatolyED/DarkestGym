using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObject/UnitScriptableObject")]
public class Unit : ScriptableObject
{
    [SerializeField] public string _name;
}
