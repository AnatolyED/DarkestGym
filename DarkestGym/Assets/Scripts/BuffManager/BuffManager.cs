using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField] private List<InfinityBuff> _infinityBuffs = new List<InfinityBuff>();
    [SerializeField] private List<TemporaryBuff> _temporaryBuffs = new List<TemporaryBuff>();

    public void AddInfinnityBuff(InfinityBuff ib)
    {
        _infinityBuffs.Add(ib);
    }

    public void AddTemporaryBuff(TemporaryBuff tb)
    {
        _temporaryBuffs.Add(tb);
    }

    public void RemoveInfinityBuff(InfinityBuff ib)
    {
        _infinityBuffs.Remove(ib);
    }

    public void RemoveTemporaryBuff(TemporaryBuff tb)
    {
        _temporaryBuffs.Remove(tb);
    }

    public List<InfinityBuff> GetInfinityBuffsList()
    {
        return new List<InfinityBuff>(_infinityBuffs);
    }

    public List<TemporaryBuff> GetTemporaryBuffsList() 
    {
        return new List<TemporaryBuff>(_temporaryBuffs);
    }
}
