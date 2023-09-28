using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsDataManager : MonoBehaviour
{
    public static BuffsDataManager Instance { get; private set; }

    [SerializeField] private RangeLvl1BuffData _rangeLvl1BuffData;

    public RangeLvl1BuffData RangeLvl1BuffData => _rangeLvl1BuffData;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("BuffsDataManager Instance is not equal null on Awake method");
        }
        Instance = this;
    }
}
