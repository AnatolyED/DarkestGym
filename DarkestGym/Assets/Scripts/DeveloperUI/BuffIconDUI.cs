using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuffIconDUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buffNameText;
    [SerializeField] private TextMeshProUGUI _movesLeftText;

    public TextMeshProUGUI BuffNameText
    {
        get
        {
            if (_buffNameText == null) Debug.LogError("_buffNameText is null");
            return _buffNameText;
        }
    }

    public TextMeshProUGUI MovesLeftText
    {
        get
        {
            if (_movesLeftText == null) Debug.LogError("_movesLeftText is null");
            return _movesLeftText;
        }
    }
}
