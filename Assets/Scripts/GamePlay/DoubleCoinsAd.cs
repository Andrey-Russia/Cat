using UnityEngine;
using YG;

public class DoubleCoinsAd : MonoBehaviour
{
    public void ShowAd()
    {
        YG2.RewardedAdvShow("doubleCoins");
    }

    public void Reward()
    {
        AutoMinerManager.Instance
            .ActivateIncomeBoost(2f, 60f);
    }
}