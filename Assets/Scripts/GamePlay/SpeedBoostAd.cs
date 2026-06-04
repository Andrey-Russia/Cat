using UnityEngine;
using YG;

public class SpeedBoostAd : MonoBehaviour
{
    public void ShowAd()
    {
        YG2.RewardedAdvShow("speedBoost");
    }

    public void Reward()
    {
        AutoMinerManager.Instance
            .ActivateSpeedBoost(3f, 30f);
    }
}