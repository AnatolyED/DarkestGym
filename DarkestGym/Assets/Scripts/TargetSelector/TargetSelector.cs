using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelector
{
    private static bool _targetSelectorIsActive = false;
    private Coroutine _clickListener; 

    public static bool TargetSelectorIsActive => _targetSelectorIsActive;

    public event System.Action<BaseUnit> OnTargetSelected;
    public event System.Action OnTargetNotSelected;
    public event System.Action OnTargetSelectorEnd;

    public TargetSelector() : this(null, Vector2.zero)
    {
        
    }

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
