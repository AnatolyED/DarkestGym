using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class Actions : MonoBehaviour
{
    public static float Block(int point,float armor, float armorMultiplyer) 
    {
        float protectionHealth = (Mathf.Pow(armorMultiplyer, point))* armor * point;
        return protectionHealth;
    }
    /*public static void Move(GameObject unit, Cell nextPosition)
    {
        while (Vector3.Distance(unit.transform.position, nextPosition.gameObject.transform.position) >= 0.1f)
        {
            unit.transform.position += Vector3.MoveTowards(unit.transform.position, nextPosition.gameObject.transform.position, 1f * Time.deltaTime);
        }
        nextPosition.GetUnit = unit;
    }*/
    public static float Attack(int point, BaseUnit unit)
    {
        float damage = Mathf.Pow(unit.DamageMultiplier,point) * unit.Damage * point; //((point * (unit.DamageMultiplier - 1)) + 1) * unit.Damage;
        return damage;
    }
    public static void Ability()
    {

    }

    public static IEnumerator Move(GameObject unit, Cell nextPosition)
    {
        while (Vector3.Distance(unit.transform.position, nextPosition.gameObject.transform.position) >= 0f)
        {
            unit.transform.position = Vector3.MoveTowards(unit.transform.position, nextPosition.gameObject.transform.position, 1f * Time.deltaTime);
            unit.GetComponent<BaseUnit>().Animator.SetTrigger("WalkTrigger");
            yield return null;
        }
        unit.GetComponent<BaseUnit>().Animator.SetTrigger("IdleTrigger");
        nextPosition.GetUnit = unit;
        yield return true;
    }

    public static IEnumerator FindinPath()
    {
        List<Cell> finalPath;
        

        yield return null;
    }
}
