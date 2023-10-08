using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActiveAbilityButtonDUI : MonoBehaviour
{
    [SerializeField] private Button _abilityButton;
    [SerializeField] private TextMeshProUGUI _abilityNameText;

    public Button AbilityButton
    {
        get
        {
            if (_abilityButton == null) Debug.LogError("_abilityButton is null");
            return _abilityButton;
        }
    }

    public TextMeshProUGUI AbilityNameText
    {
        get
        {
            if (_abilityNameText == null) Debug.LogError("_abilityNameText is null");
            return _abilityNameText;
        }
    }
}
