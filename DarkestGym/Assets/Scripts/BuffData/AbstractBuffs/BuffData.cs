using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BuffData : ScriptableObject
{
    [SerializeField] private Image _image;
    [SerializeField] private string _name;

    #region Getter
    public Image Image
    {
        get { return _image; }
        set { _image = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    #endregion
}
