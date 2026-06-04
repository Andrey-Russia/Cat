using TMPro;
using UnityEngine;
using YG;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance { get; private set; }

    [SerializeField] private GameObject _achievementPanel;
    [SerializeField] private TMP_Text _achievementText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _achievementPanel.SetActive(false); 
    }

    public void CheckAchievements()
    {
        if (!YG2.saves.tutorialCompleted)
        {
            return;
        }

        CheckCoinAchievements();
        CheckCatAchievements();
    }

    private void CheckCoinAchievements()
    {
        int coins = CurrencyManager.Instance.Coins;

        if (coins >= 1 &&
            !YG2.saves.achievementFirstCoin)
        {
            Unlock(
                ref YG2.saves.achievementFirstCoin,
                "Первая монета");
        }

        if (coins >= 100 &&
            !YG2.saves.achievement100Coins)
        {
            Unlock(
                ref YG2.saves.achievement100Coins,
                "100 монет");
        }

        if (coins >= 1000 &&
            !YG2.saves.achievement1000Coins)
        {
            Unlock(
                ref YG2.saves.achievement1000Coins,
                "1000 монет");
        }
    }

    private void CheckCatAchievements()
    {
        int cats =
            AutoMinerManager.Instance.CatsCount;

        if (cats >= 1 &&
            !YG2.saves.achievementFirstCat)
        {
            Unlock(
                ref YG2.saves.achievementFirstCat,
                "Первый кот");
        }

        if (cats >= 10 &&
            !YG2.saves.achievement10Cats)
        {
            Unlock(
                ref YG2.saves.achievement10Cats,
                "10 котов");
        }
    }

    private void Unlock(
        ref bool achievement,
        string achievementName)
    {
        achievement = true;

        _achievementPanel.SetActive(true);

        _achievementText.text =
            $"🏆 Достижение открыто!\n\n{achievementName}";

        Invoke(nameof(HidePanel), 3f);

        YG2.SaveProgress();
    }

    private void HidePanel()
    {
        _achievementPanel.SetActive(false);
    }
}