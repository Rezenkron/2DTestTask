using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue;
    public static int CoinAmount { get; private set; }

    public static event Action<int> OnCollect;

    private void Start()
    {
        CoinAmount = coinValue;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collect();
    }

    private void Collect()
    {
        OnCollect?.Invoke(CoinAmount);
        CoinAmount += coinValue;
        gameObject.SetActive(false);
    }
}
