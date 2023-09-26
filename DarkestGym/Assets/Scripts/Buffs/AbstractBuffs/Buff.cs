using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Buff : ScriptableObject
{
    public Image Image { get; set; }
    public string Name { get; set; }

    public abstract void Use();
    public abstract void Unuse();

    protected abstract void ActivateBuff();
    protected abstract void DeactivateBuff();
    protected abstract void OnMoveAction();
}
