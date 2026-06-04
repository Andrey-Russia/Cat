using TMPro;
using UnityEngine;
using YG;

public class BuyCatUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private InteractiveButton _interactiveButton;
    [SerializeField] private MiniCatSpawner _miniCatSpawner;
    [SerializeField] private int _basePrice = 25;

    private int _level;
    public int Level => _level;
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

        _miniCatSpawner.SpawnCat();

        Save();

        if (TutorialManager.Instance.CurrentStep == 2)
        {
            TutorialManager.Instance.CompleteStep();
        }
    }

    public void Save()
    {
        YG2.saves.catLevel = _level;

        YG2.saves.catCount =
            AutoMinerManager.Instance.CatsCount;

        YG2.SaveProgress();
    }

    public void LoadFromCloud()
    {
        _level = YG2.saves.catLevel;

        for (int i = 0; i < YG2.saves.catCount; i++)
        {
            AutoMinerManager.Instance.AddCat();

            _miniCatSpawner.SpawnCat();
            AchievementManager.Instance.CheckAchievements();
        }
    }
}