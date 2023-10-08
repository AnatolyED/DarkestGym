using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsDataManager : MonoBehaviour
{
    public static BuffsDataManager Instance { get; private set; }

    [SerializeField] private RangeLvl1BuffData _rangeLvl1BuffData;
    [SerializeField] private TankLvl1BuffData _tankLvl1BuffData;
    [SerializeField] private FeiChaoFirstBuffData _feiChaoFirstBuffData;
    [SerializeField] private FeiChaoSecondBuffData _feiChaoSecondBuffData;
    [SerializeField] private GigajabFirstBuffData _gigajabFirstBuffData;

    public RangeLvl1BuffData RangeLvl1BuffData => _rangeLvl1BuffData;
    public TankLvl1BuffData TankLvl1AbilityData => _tankLvl1BuffData;
    public FeiChaoFirstBuffData FeiChaoFirstBuffData => _feiChaoFirstBuffData;
    public FeiChaoSecondBuffData FeiChaoSecondBuffData => _feiChaoSecondBuffData;
    public GigajabFirstBuffData GigajabFirstBuffData => _gigajabFirstBuffData;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("BuffsDataManager Instance is not equal null on Awake method");
        }
        Instance = this;
    }
}
