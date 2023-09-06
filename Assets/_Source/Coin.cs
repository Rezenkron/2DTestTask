using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinLauncher launcher;
    [SerializeField] private int coinValue;

    public event Action<int> OnCollect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collect();
    }

    public void Collect()
    {
        transform.position = launcher.transform.position;
        OnCollect?.Invoke(coinValue);
        gameObject.SetActive(false);
    }
}
