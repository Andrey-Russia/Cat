using TMPro;
using UnityEngine;

public class BuyCatUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private InteractiveButton _interactiveButton;

    [SerializeField] private int _basePrice = 25;

    private int _level;

    private int CurrentPrice =>
        Mathf.RoundToInt(_basePrice * Mathf.Pow(1.7f, _level));

    private void Update()
    {
        _priceText.text = $"Автокот | LVL {_level} | {CurrentPrice}";
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

        AutoMinerManager.Instance.AddCat();
    }
}