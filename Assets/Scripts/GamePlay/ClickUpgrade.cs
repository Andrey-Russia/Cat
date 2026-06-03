using TMPro;
using UnityEngine;

public class ClickUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private InteractiveButton _interactiveButton;

    [SerializeField] private int _basePrice = 10;

    private int _level;

    private int CurrentPrice =>
        Mathf.RoundToInt(_basePrice * Mathf.Pow(1.6f, _level));

    private void Update()
    {
        _priceText.text = $"Клик +1 | LVL {_level} | {CurrentPrice}";
    }

    public void Buy()
    {
        if (!CurrencyManager.Instance.SpendCoins(CurrentPrice))
        {
            _interactiveButton.PlayErrorSound();
            return;
        }

        _interactiveButton.PlaySuccessSound();

        _level++;

        PlayerStats.Instance.IncreaseClickPower(1);
    }
}