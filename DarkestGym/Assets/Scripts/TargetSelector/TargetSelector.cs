using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that realize logic of selecting units (BaseUnits)
/// </summary>
public class TargetSelector
{
    private static bool _targetSelectorIsActive = false;
    private Coroutine _clickListener; 

    /// <summary>
    /// Shows if another TargetSelector is active now.
    /// If another TargetSelector is active now, new TargetSelector will 
    /// not be created.
    /// </summary>
    public static bool TargetSelectorIsActive => _targetSelectorIsActive;

    /// <summary>
    /// Fires when user selects unit (first param)
    /// </summary>
    public event System.Action<BaseUnit> OnTargetSelected;
    /// <summary>
    /// Fires if user clicked but did not select unit
    /// </summary>
    public event System.Action OnTargetNotSelected;
    /// <summary>
    /// Fires after OnTargerSelected and OnTargerNotSelected and 
    /// finishes work of target selector
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
        if (!TargetSelectorIsActive)
        {
            Cursor.SetCursor(cursorTexture, hotspot, CursorMode.Auto);
            OnTargetSelectorEnd += () =>
            {
                GameManager.Instance.StopCoroutine(_clickListener);
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                _targetSelectorIsActive = false;
            };
            _clickListener = GameManager.Instance.StartCoroutine(ClickListener());
            _targetSelectorIsActive = true;
        }
        else
        {
            Debug.LogError("Currently selecting something, close previous TargetSelector to use new");
        }
    }

    /// <summary>
    /// Forcing finish of TargetSelector
    /// </summary>
    public void Close()
    {
        OnTargetSelectorEnd();
    }

    private IEnumerator ClickListener()
    {
        while(true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Ray ray = GameManager.Instance.GetGamera.ScreenPointToRay(mousePosition);
                bool targetWasSelected = false;
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if(hit.transform.gameObject.TryGetComponent(out Cell hittedCell))
                    {
                        if(hittedCell.GetUnit != null)
                        {
                            if(hittedCell.GetUnit.TryGetComponent(out BaseUnit baseUnit))
                            {
                                OnTargetSelected?.Invoke(baseUnit);
                                targetWasSelected = true;
                            }
                            else
                            {
                                Debug.LogError("There is no BaseUnit script on selected unit prefab");
                            }
                        }
                    }
                }
                if(!targetWasSelected) OnTargetNotSelected();
                OnTargetSelectorEnd?.Invoke();
            }
            yield return null;
        }
    }
}
