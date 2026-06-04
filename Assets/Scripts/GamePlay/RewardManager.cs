using UnityEngine;
using YG;

public class RewardManager : MonoBehaviour
{
    private void OnEnable()
    {
        YG2.onRewardAdv += Reward;
    }

    private void OnDisable()
    {
        YG2.onRewardAdv -= Reward;
    }

    private void Reward(string id)
    {
        switch (id)
        {
            case "doubleCoins":
                AutoMinerManager.Instance
                    .ActivateIncomeBoost(2f, 60f);
                break;

            case "speedBoost":
                AutoMinerManager.Instance
                    .ActivateSpeedBoost(3f, 30f);
                break;
        }
    }
}