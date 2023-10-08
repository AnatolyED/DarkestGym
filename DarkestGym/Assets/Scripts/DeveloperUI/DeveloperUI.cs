using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeveloperUI : MonoBehaviour
{
    [SerializeField] private GameObject _developerUICanvas;

    [SerializeField] private GameObject _activeAbilitiesBar;
    [SerializeField] private GameObject _passiveAbilitiesBar;
    [SerializeField] private GameObject _buffsBar;

    [SerializeField] private ActiveAbilityButtonDUI _activeAbilityBtnPrefab;
    [SerializeField] private PassiveAbilityIconDUI _passiveAbilityIconPrefab;
    [SerializeField] private BuffIconDUI _buffIconPrefab;

    /// <summary>
    /// Ref to singletone of DeveloperUI
    /// </summary>
    public static DeveloperUI Instance { get; private set; }

    public GameObject DeveloperUICanvas => _developerUICanvas;

    public GameObject ActiveAbilitiesBar => _activeAbilitiesBar;
    public GameObject PassiveAbilitiesBar => _passiveAbilitiesBar;
    public GameObject BuffsBar => _buffsBar;

    public ActiveAbilityButtonDUI ActiveAbilityBtnPrefab => _activeAbilityBtnPrefab;
    public PassiveAbilityIconDUI PassiveAbilityIconPrefab => _passiveAbilityIconPrefab;
    public BuffIconDUI BuffIconPrefab => _buffIconPrefab;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("There is Instance of DeveloperUI before Awake method");
        }
        Instance = this;
    }

    public void ShowActiveAbilities(BaseUnit unit)
    {
        int num = 0;
        Vector3 margin = new Vector3(200, 0, 0);
        ClearBar(_activeAbilitiesBar);
        foreach (var activeAbility in unit.ActiveAbilities)
        {
            var btn = Instantiate(ActiveAbilityBtnPrefab, ActiveAbilitiesBar.transform);
            btn.AbilityNameText.text = activeAbility.Name;
            btn.transform.position += margin * num++;
            btn.AbilityButton.onClick.AddListener(() =>
            {
                Debug.Log("Started... " + activeAbility.Name);
                activeAbility.StartPrepare();
            });
        }
    }

    public void ShowPassiveAbilities(BaseUnit unit)
    {
        int num = 0;
        Vector3 margin = new Vector3(200, 0, 0);
        ClearBar(_passiveAbilitiesBar);
        foreach (var passiveAbility in unit.PassiveAbilities)
        {
            var gm = Instantiate(PassiveAbilityIconPrefab, PassiveAbilitiesBar.transform);
            gm.AbilityNameText.text = passiveAbility.Name;
            gm.transform.position += margin * num++;
        }
    }

    public void ShowBuffs(BaseUnit unit)
    {
        ClearBar(_buffsBar);
        int num = 0;
        Vector3 margin = new Vector3(200, 0, 0);
        foreach (var buff in unit.BuffManager.GetInfinityBuffsList())
        {
            var buffGm = Instantiate(BuffIconPrefab, BuffsBar.transform);
            buffGm.BuffNameText.text = buff.Name;
            buffGm.transform.position += margin * num++;
        }
        foreach (var buff in unit.BuffManager.GetTemporaryBuffsList())
        {
            var buffGm = Instantiate(BuffIconPrefab, BuffsBar.transform);
            buffGm.BuffNameText.text = buff.Name;
            buffGm.MovesLeftText.text = buff.MovesLeft.ToString();
            buffGm.transform.position += margin * num++;
        }
    }

    private void ClearBar(GameObject barGm)
    {
        foreach (Transform child in barGm.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
