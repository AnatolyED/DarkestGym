using UnityEngine;
using UnityEngine.UI;

public abstract class Ability
{
    public Image Image { get; protected set; }
    public string Name { get; protected set; }
    public BaseUnit AbilityOwner { get; protected set; }

    public Ability(Image image, string name, BaseUnit abilityOwner)
    {
        Image = image;
        Name = name;
        AbilityOwner = abilityOwner;
    }
}