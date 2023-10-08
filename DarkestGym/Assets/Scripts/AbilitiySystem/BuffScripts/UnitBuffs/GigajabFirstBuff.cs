using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GigajabFirstBuff : InfinityBuff
{
    public float DamageLimit { get; private set; }
    public float CounterDamage { get; private set; }

    private System.Action<BaseUnit, float> _beenDamagedHandler = null;

    public GigajabFirstBuff(Image image, string name, BaseUnit buffOwner, float damageLimit, float counterDamage) : base(image, name, buffOwner) 
    {
        DamageLimit = damageLimit;
        CounterDamage = counterDamage;
    }

    protected override void ActivateBuff()
    {
        _beenDamagedHandler = (attacker, damageVal) =>
        {
            if(damageVal <= DamageLimit)
            {
                attacker.TakeDamage(BuffOwner, CounterDamage);
            }
        };
        BuffOwner.OnBeenDamaged += _beenDamagedHandler;
    }

    protected override void DeactivateBuff()
    {
        BuffOwner.OnBeenDamaged -= _beenDamagedHandler;
        _beenDamagedHandler = null;
    }

    protected override void OnMoveAction()
    {

    }
}
