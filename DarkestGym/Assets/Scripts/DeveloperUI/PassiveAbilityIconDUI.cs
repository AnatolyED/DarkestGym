using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PassiveAbilityIconDUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _abilityNameText;

    public TextMeshProUGUI AbilityNameText
    {
        get
        {
            if (_abilityNameText == null) Debug.LogError("_abilityNameText is null");
            return _abilityNameText;
        }
    }
}
