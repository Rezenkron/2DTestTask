using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinLauncher launcher;
    [SerializeField] private int coinValue;
    [SerializeField] public int CoinAmount { get; private set; }

    public event Action<int> OnCollect;
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
        transform.position = launcher.transform.position;
        OnCollect?.Invoke(CoinAmount);
        CoinAmount += coinValue;
        gameObject.SetActive(false);
    }
}
