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
    public static float Attack(int point, BaseUnit unit)
    {
        float damage = Mathf.Pow(unit.DamageMultiplier,point) * unit.Damage * point; //((point * (unit.DamageMultiplier - 1)) + 1) * unit.Damage;
        return damage;
    }
    public static void Ability()
    {

    }

    public static IEnumerator Move(GameObject unit, Cell nextPosition, bool completeAction)
    {
        while (Vector3.Distance(unit.transform.position, nextPosition.gameObject.transform.position) >= 0.1f)
        {
            unit.transform.position = Vector3.MoveTowards(unit.transform.position, nextPosition.gameObject.transform.position, 1f * Time.deltaTime);
            yield return null;
        }
        nextPosition.GetUnit = unit;
        completeAction = true;
        Debug.Log("� �����" + completeAction);
        yield return true;
    }
}
