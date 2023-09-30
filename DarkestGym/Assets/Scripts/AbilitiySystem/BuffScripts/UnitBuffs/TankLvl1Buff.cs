using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankLvl1Buff : InfinityBuff
{
    // KOSTIL
    // Ask Sanya how this ability must work in the case of two tanks
    private int _charges = 1;
    
    public float ReturnDamageMult {  get; private set; }

    public TankLvl1Buff(Image image, string name, BaseUnit buffOwner, float returnDamageMult) : base(image, name, buffOwner)
    {
        ReturnDamageMult = returnDamageMult;
    }

    protected override void ActivateBuff()
    {
        BuffOwner.OnBeenDamaged += BuffLogic;
    }

    protected override void DeactivateBuff()
    {
        BuffOwner.OnBeenDamaged -= BuffLogic;
    }

    protected override void OnMoveAction()
    {

    }

    private void BuffLogic(BaseUnit damageSource, float damage)
    {
        if (_charges > 0 && damageSource.Range <= 1) 
        {
            damageSource.TakeDamage(BuffOwner, damage * ReturnDamageMult);
            _charges--;
        }
    }
}
