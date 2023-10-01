using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeiChaoFirstAbility : ActiveAbility
{
    private BaseUnit _target;
    private TargetSelector _ts;

    public FeiChaoFirstAbility(Image image, string name, BaseUnit abilityOwner, int abilityCost, int cooldown) : 
        base(image, name, abilityOwner, abilityCost, cooldown)
    {

    }

    public override void StartPrepare()
    {
        _ts = new TargetSelector();
        _ts.OnTargetSelected += (unit) =>
        {
            _target = unit;
            if(_target.GetUnitNumber == AbilityOwner.GetUnitNumber)
            {
                BuffsDataManager.Instance.FeiChaoFirstBuffData.GetBuff(unit).Use();
                Debug.Log("Used to " + unit.Name);
                AbilityOwner.ScorePoint -= AbilityCost;
                _ts.Close();
            }
            else
            {
                Debug.Log("“кни по союзнику!!");
            }
        };
        _ts.OnTargetNotSelected += () =>
        {
            _ts.Close();
        };
    }

    public override void StopPrepare()
    {

    }

    protected override void UseAbility()
    {

    }
}
