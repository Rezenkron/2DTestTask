using TMPro;
using UnityEngine;

public class CoinTextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Coin coin;

    private void OnEnable()
    {
        coin.OnCollect += UpdateText;
    }

    private void OnDisable()
    {
        coin.OnCollect -= UpdateText;
    }

    private void UpdateText(int value)
    {
        if (text != null)
        {
            text.text = $"{coin.CoinAmount}";
        }
    }
}
