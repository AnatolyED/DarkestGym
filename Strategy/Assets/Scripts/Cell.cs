using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [Header("Colors and materials")]
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _baseColor;

    [Space, Header("Unit")]
    [SerializeField] private GameObject _unitOnTheCell;
    public GameObject GetUnit
    {
        get { return _unitOnTheCell; }
        set 
        {
            if (_unitOnTheCell == null)
            {
                _unitOnTheCell = value;
            }
            else Debug.Log("Место уже занято! Ход сюда не возможен");
        }
    }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _baseColor = _meshRenderer.material.color;
    }
    private void ChangeColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
    private void OnMouseEnter()
    {
        ChangeColor(Color.green);
    }

    private void OnMouseExit()
    {
        ChangeColor(_baseColor);
    }
}
