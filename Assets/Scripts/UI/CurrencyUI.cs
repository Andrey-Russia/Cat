using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text coinsText;

    private void Update()
    {
        coinsText.text = $"{CurrencyManager.Instance.Coins}";
    }
}