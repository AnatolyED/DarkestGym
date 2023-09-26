using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : ScriptableObject
{
    public Image Image { get ; set; }
    public string Name { get; set; }
}