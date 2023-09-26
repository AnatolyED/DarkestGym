using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public static float Block(int point,float armor, float armorMultiplyer) 
    {
        float protectionHealth = armor * (Mathf.Pow(armorMultiplyer, point));
        return protectionHealth;
    }
    public static void Move(GameObject unit, Cell nextPosition)
    {
        while (Vector3.Distance(unit.transform.position, nextPosition.gameObject.transform.position) >= 0.05f)
        {
            unit.transform.position = Vector3.MoveTowards(unit.transform.position, nextPosition.gameObject.transform.position, Time.deltaTime);
        }
        nextPosition.GetUnit = unit;
    }
    public static float Attack(int point, BaseUnit unit)
    {
        float damage = point * unit.DamageMultiplier * unit.Damage;
        return damage;
    }
    public static void Ability()
    {

    }


}
