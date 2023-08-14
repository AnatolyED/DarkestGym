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
    public static void Move()
    {

    }
    public static void Attack(int point,float damage, float damageMultiplyer,List<AbilityName> ability,BaseUnit enemy)
    {


    }
    public static void Ability()
    {

    }


}
