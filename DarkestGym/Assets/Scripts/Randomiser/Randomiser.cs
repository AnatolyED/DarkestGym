using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;
using UnityEngine;

public class Randomiser<T>
{
    private Dictionary<T, float> _chancesDict = new Dictionary<T, float>();
    private Dictionary<T, Tuple<float, float>> _chancesTuples = new Dictionary<T, Tuple<float, float>>();
    private bool _isCalculated = false;
    private float _allChances = 0;

    public Randomiser() 
    { 
    
    }

    public void Add(T item, float chance)
    {
        _chancesDict.Add(item, chance);
        _allChances += chance;
        _isCalculated = false;
    }

    public void Remove(T item) 
    { 
        _allChances -= _chancesDict[item];
        _chancesDict.Remove(item);
        _isCalculated = false;
    }

    public T Get()
    {
        if(_chancesDict.Count == 0)
        {
            Debug.LogError("There is no items to randomise");
            return default;
        }
        if(!_isCalculated)
        {
            Recalculate();
            _isCalculated = true;
        }
        return GetItemByChance();
    }

    private void Recalculate()
    {
        float k = 100f / _allChances;
        float prevChance = 0;
        foreach(var pairItemChance in _chancesDict) 
        {
            var newTuple = new Tuple<float, float>(prevChance * k, (prevChance += pairItemChance.Value) * k);
            _chancesTuples.Add(pairItemChance.Key, newTuple);
        }
    }

    private T GetItemByChance()
    {
        float randNum = Random.Range(0f, 100f);
        foreach(var pairItemChance in _chancesTuples)
        {
            if(pairItemChance.Value.Item1 <= randNum && pairItemChance.Value.Item2 >= randNum)
            {
                return pairItemChance.Key;
            }
        }
        // smth went wrong
        return _chancesTuples.Keys.First();
    }
}
