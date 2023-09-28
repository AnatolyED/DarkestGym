using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeLvl1Buff : InfinityBuff
{
    public int DistanceToWeak { get; private set; }

    public RangeLvl1Buff(Image image, string name, BaseUnit buffOwner, int distanceToWeak) : base(image, name, buffOwner)
    {
        DistanceToWeak = distanceToWeak;
    }

    protected override void ActivateBuff()
    {
        
    }

    protected override void DeactivateBuff() 
    {
    
    }

    protected override void OnMoveAction()
    {
        
    }
}
