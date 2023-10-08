using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that realize logic of selecting units (BaseUnits)
/// </summary>
public class TargetSelector
{
    private Coroutine _clickListener = null; 
    private static LinkedList<TargetSelector> _targetSelectorList = new LinkedList<TargetSelector>();
    private static TargetSelector _currentTargetSelector = null;

    private Texture2D _cursorTexture;
    private Vector2 _hotspot;

    /// <summary>
    /// Shows if this TargetSelector is active now 
    /// </summary>
    public bool IsActive { get; private set; }

    /// <summary>
    /// Amount of existing TargetSelectors
    /// </summary>
    public int TargetSelectorsCount => _targetSelectorList.Count + (_currentTargetSelector == null ? 0 : 1);

    /// <summary>
    /// Fires when user selects unit (first param)
    /// </summary>
    public event System.Action<BaseUnit> OnUnitSelected;
    /// <summary>
    /// Fires when user selects block (first param) with unit
    /// on it or without
    /// </summary>
    public event System.Action<Cell> OnCellSelected;
    /// <summary>
    /// Fires if user clicked but did not select unit or block
    /// </summary>
    public event System.Action OnNothingSelected;
    /// <summary>
    /// Fires when click happens, before OnTargetSelected
    /// and OnTargetNotSelected events
    /// </summary>
    public event System.Action OnClick;
    /// <summary>
    /// Fires after closing TargetSelector
    /// </summary>
    public event System.Action OnTargetSelectorEnd;

    /// <summary>
    /// Creates TargetSelector and launches it with default cursor
    /// </summary>
    public TargetSelector() : this(null, Vector2.zero)
    {
        
    }

    /// <summary>
    /// Creates TargetSelector and launches it with custom cursor
    /// </summary>
    public TargetSelector(Texture2D cursorTexture, Vector2 hotspot)
    {
        _cursorTexture = cursorTexture;
        _hotspot = hotspot;

        if (_currentTargetSelector == null)
        {
            _currentTargetSelector = this;
        }
        else
        {
            _currentTargetSelector.IsActive = false;
            _targetSelectorList.AddFirst(_currentTargetSelector);
            GameManager.Instance.StopCoroutine(_currentTargetSelector._clickListener);
            _currentTargetSelector = this;
        }

        IsActive = true;
        Cursor.SetCursor(_cursorTexture, _hotspot, CursorMode.Auto);
        _clickListener = GameManager.Instance.StartCoroutine(ClickListener());
    }

    /// <summary>
    /// Forcing finish TargetSelector
    /// </summary>
    public void Close()
    {
        IsActive = false;
        GameManager.Instance.StopCoroutine(_currentTargetSelector._clickListener);
        _currentTargetSelector = null;

        if (_targetSelectorList.Count > 0)
        {
            _currentTargetSelector = _targetSelectorList.First.Value;
            _targetSelectorList.RemoveFirst();
            _currentTargetSelector.IsActive = true;
            Cursor.SetCursor(_currentTargetSelector._cursorTexture, _currentTargetSelector._hotspot, CursorMode.Auto);
            GameManager.Instance.StartCoroutine(Delay());
        }
        else
        { 
            Cursor.SetCursor(_cursorTexture, _hotspot, CursorMode.Auto);
        }

        OnTargetSelectorEnd?.Invoke();
    }

    private IEnumerator Delay()
    {
        const float delay = 1f;
        yield return new WaitForSeconds(delay);
        _currentTargetSelector._clickListener = GameManager.Instance.StartCoroutine(_currentTargetSelector.ClickListener());
    }

    private IEnumerator ClickListener()
    {
        while(true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick?.Invoke();
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = GameManager.Instance.GetGamera.ScreenPointToRay(mousePosition);
                bool targetWasSelected = false;
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if(hit.transform.gameObject.TryGetComponent(out Cell hittedCell))
                    {
                        OnCellSelected?.Invoke(hittedCell);
                        if(hittedCell.GetUnit != null)
                        {
                            if(hittedCell.GetUnit.TryGetComponent(out BaseUnit baseUnit))
                            {
                                OnUnitSelected?.Invoke(baseUnit);
                                targetWasSelected = true;
                            }
                            else
                            {
                                Debug.LogError("There is no BaseUnit script on selected unit prefab");
                            }
                        }
                    }
                }
                if (!targetWasSelected)
                {
                    OnNothingSelected?.Invoke();
                }
            }
            yield return null;
        }
    }
}
