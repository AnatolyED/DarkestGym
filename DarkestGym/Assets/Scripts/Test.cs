using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    public void Attack()
    {
        Debug.Log("�����");
    }
    public void Block()
    {
        Debug.Log("����");
    }
    public void Move()
    {
        Debug.Log("��������");
    }
    public void Ability()
    {
        Debug.Log("�����������");
    }
    public void Wait()
    {
        Debug.Log("��������");
    }
}
