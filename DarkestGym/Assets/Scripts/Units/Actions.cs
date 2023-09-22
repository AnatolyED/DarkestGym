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
    public static void Move(GameObject unit,Transform startPosition, Transform nextPosition)
    {
        unit.transform.Translate(new Vector3(nextPosition.position.x,unit.transform.position.y,nextPosition.position.z));
    }
    public static void Attack(int point,float damage, float damageMultiplyer,List<Ability> ability,BaseUnit enemy)
    {


    }
    public static void Ability()
    {

    }


}
