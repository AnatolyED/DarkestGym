using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionManager : MonoBehaviour
{
    [Header("Менеджеры")]
    [SerializeField] private RoundManager RoundManger;

    [Header("Данные для взаимодействия")]
    [SerializeField] private GameObject _unit;
    [SerializeField] private UnitActivity _unitAction = UnitActivity.Idle;
    public GameObject GetSetUnit
    {
        get { return _unit; }
        set { _unit = value; }
    }

    private IEnumerator UnitAction()
    {
        while (true)
        {
            if (_unit.GetComponent<BaseUnit>().GetSetScorePoint > 0)
            {
                switch (_unitAction)
                {
                    case UnitActivity.Idle:

                        break;
                    case UnitActivity.Attack:

                        break;
                    case UnitActivity.Block:

                        break;
                    case UnitActivity.Skill:

                        break;
                    case UnitActivity.Walk:

                        break;
                }
            }
            else
            {
                RoundManger.SetChangingTheTaget = true;
            }

            yield return null;
        }
    }
}
