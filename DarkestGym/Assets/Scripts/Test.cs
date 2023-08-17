using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    public void Attack()
    {
        Debug.Log("Атака");
    }
    public void Block()
    {
        Debug.Log("Блок");
    }
    public void Move()
    {
        Debug.Log("Движение");
    }
    public void Ability()
    {
        Debug.Log("Способности");
    }
    public void Wait()
    {
        Debug.Log("Ожидание");
    }
}
