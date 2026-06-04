using System;
using TMPro;
using UnityEngine;
using YG;

public class OfflineIncomeManager : MonoBehaviour
{
    [SerializeField] private int _maxOfflineHours = 8;
    [SerializeField] private GameObject _rewardPanel;
    [SerializeField] private TMP_Text _rewardText;


    private void Start()
    {
        CalculateOfflineIncome();
    }

    private void OnApplicationQuit()
    {
        SaveExitTime();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveExitTime();
        }
    }

    private void SaveExitTime()
    {
        YG2.saves.hasExitedGame = true;

        YG2.saves.lastExitTime =
            DateTime.UtcNow.ToString();

        YG2.SaveProgress();
    }  

    private void CalculateOfflineIncome()
    {
        Debug.Log("hasExitedGame = " + YG2.saves.hasExitedGame);
        Debug.Log("lastExitTime = " + YG2.saves.lastExitTime);
        if (!YG2.saves.hasExitedGame)
        {
            return;
        }

        if (string.IsNullOrEmpty(YG2.saves.lastExitTime))
        {
            return;
        }

        if (string.IsNullOrEmpty(YG2.saves.lastExitTime))
            return;

        DateTime lastExit =
            DateTime.Parse(YG2.saves.lastExitTime);

        TimeSpan offlineTime =
            DateTime.UtcNow - lastExit;

        double seconds =
            Math.Min(
                offlineTime.TotalSeconds,
                _maxOfflineHours * 3600);

        int income =
            Mathf.RoundToInt(
                AutoMinerManager.Instance.IncomePerSecond *
                (float)seconds);

        if (income <= 0)
            return;

        CurrencyManager.Instance.AddCoins(income);
        _rewardPanel.SetActive(true);

        _rewardText.text =
            $"Пока вас не было:\n+{income} монет";

        YG2.saves.lastExitTime =
    DateTime.UtcNow.ToString();

        YG2.SaveProgress();
    }

    public void CloseRewardPanel()
    {
        _rewardPanel.SetActive(false);
    }
}