using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinnetSecondAbility : ActiveAbility
{
    public LinnetSecondAbility(Image image, string name, BaseUnit abilityOwner, int abilityCost, int cooldown) : 
        base(image, name, abilityOwner, abilityCost, cooldown)
    {

    }

    public override void StartPrepare()
    {
        TargetSelector abilityTs = new TargetSelector();
        abilityTs.OnUnitSelected += (unit) =>
        {
            if(unit.GetUnitNumber == AbilityOwner.GetUnitNumber)
            {
                Cell.SwapCellsUnits(AbilityOwner.CurrentCell, unit.CurrentCell);
                abilityTs.Close();
            }
        };
    }

    public override void StopPrepare()
    {

    }

    protected override void UseAbility()
    {

    }
}
