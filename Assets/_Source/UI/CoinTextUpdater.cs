using TMPro;
using UnityEngine;

public class CoinTextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void OnEnable()
    {
        Coin.OnCollect += UpdateText;
    }

    private void OnDisable()
    {
        Coin.OnCollect -= UpdateText;
    }

    private void UpdateText(int value)
    {
        if (text != null)
        {
            text.text = $"{Coin.CoinAmount}";
        }
    }
}
