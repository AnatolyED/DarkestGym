using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Buff
{
    public Image Image { get; set; }
    public string Name { get; set; }
    public BaseUnit BuffOwner { get; protected set; }

    public Buff(Image image, string name, BaseUnit buffOwner)
    {
        Image = image;
        Name = name;
        BuffOwner = buffOwner;
    }

    public abstract void Use();
    public abstract void Unuse();

    protected abstract void ActivateBuff();
    protected abstract void DeactivateBuff();
    protected abstract void OnMoveAction();
}
