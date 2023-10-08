using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.UI;

public class GigajabSecondAbility : ActiveAbility
{
    public int Duration {  get; private set; }
    public List<GameObject> GroundBlocks { get; private set; }

    public GigajabSecondAbility(Image image, string name, BaseUnit abilityOwner, int abilityCost, int cooldown, int duration, List<GameObject> groundBlocks) : 
        base (image, name, abilityOwner, abilityCost, cooldown)
    {
        Duration = duration;
        GroundBlocks = groundBlocks;
    }

    public override void StartPrepare()
    {
        TargetSelector abilityTs = new TargetSelector();
        abilityTs.OnCellSelected += (cell) =>
        {
            if (cell.GetUnit == null)
            {
                Randomiser<GameObject> blockRandomiser = new Randomiser<GameObject>();
                foreach (var groundBlock in GroundBlocks) blockRandomiser.Add(groundBlock, 1);
                // 1. make then BattleMap class with logic of creating and deleting map objects
                // 2. also make blocking cell
                GameObject randomnedBlock = Object.Instantiate(blockRandomiser.Get(), cell.transform.position, Quaternion.Euler(new Vector3(-90, 0, 0)));
                int movesLeft = Duration;
                System.Action delayToDel = null;
                delayToDel = () =>
                {
                    movesLeft--;
                    if(movesLeft <= 0)
                    {
                        Object.Destroy(randomnedBlock);
                        GameManager.Instance.RoundManager.OnNextRound -= delayToDel;
                    }
                };
                GameManager.Instance.RoundManager.OnNextRound += delayToDel;
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
