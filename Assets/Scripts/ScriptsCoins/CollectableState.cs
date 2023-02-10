using UnityEngine;
using System;


public class CollectableState
{

    private int _coinCount;
    public int CoinCount
    {
        get => _coinCount;
        set
        {
            _coinCount = value;
            OnCoinCountUpdate?.Invoke(_coinCount);
        }
    }

    public event Action<int> OnCoinCountUpdate;
}