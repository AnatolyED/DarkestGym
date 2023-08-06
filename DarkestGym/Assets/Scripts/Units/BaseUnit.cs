using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    [SerializeField] private Unit _scriptableObject;

    private void Start()
    {
        Debug.Log(_scriptableObject._name.ToString());
    }
}
