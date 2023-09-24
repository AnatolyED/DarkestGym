using UnityEngine;
using UnityEngine.UI;

public class Ability : ScriptableObject
{
    [SerializeField] private Image abilityImage;
    [SerializeField] private string abilityName;
    [SerializeField] private float coolDownTime;
    [SerializeField] private int range;
    public virtual void Activate()
    {

    }


}

[CreateAssetMenu(fileName = "Passive abillity",menuName = "CreateSkill/PassiveSkill")]
public class PassiveAbility : Ability
{
    [SerializeField] private SkillType skillType = SkillType.Passive;
}
[CreateAssetMenu(fileName = "Active abillity", menuName = "CreateSkill/ActiveSkill")]
public class ActiveAbillity : Ability
{
    [SerializeField] private SkillType skillType = SkillType.Active;


}