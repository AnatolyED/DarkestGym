using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [Header("Colors and materials")]
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _baseColor;

    [SerializeField] public GameManager _gameManager;

    [Space, Header("Unit")]
    [SerializeField] private GameObject _unitOnTheCell;

    private CellCoordinate _cellCoordinate;
    public GameObject GetUnit
    {
        get { return _unitOnTheCell; }
        set 
        {
            if (_unitOnTheCell == null)
            {
                _unitOnTheCell = value;
            }
            else
            {
                Debug.Log("����� ��� ������! ��� ���� �� ��������");
            }
        }
    }

    public CellCoordinate CellCoordinate => _cellCoordinate;

    private void Awake()
    {
        if(!TryGetComponent(out _cellCoordinate))
        {
            Debug.LogError("There is no cell coordinate on this cell");
        }
    }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        if (tag == "StoneCell") _baseColor = _meshRenderer.materials[1].color;
        else _baseColor = _meshRenderer.material.color;
    }
    private void ChangeColor(Color color)
    {
        if (tag == "StoneCell") _meshRenderer.materials[1].color = color;
        else _meshRenderer.material.color = color;
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
