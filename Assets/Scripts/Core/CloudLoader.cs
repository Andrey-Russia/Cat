using UnityEngine;
using YG;

public class CloudLoader : MonoBehaviour
{
    [SerializeField] private ClickUpgrade _clickUpgrade;
    [SerializeField] private BuyCatUpgrade _buyCatUpgrade;

    private void OnEnable()
    {
        YG2.onGetSDKData += LoadGame;
    }

    private void OnDisable()
    {
        YG2.onGetSDKData -= LoadGame;
    }

    private void LoadGame()
    {
        Debug.Log("LOAD START");

        Debug.Log("Coins: " + YG2.saves.coins);
        Debug.Log("ClickLevel: " + YG2.saves.clickLevel);
        Debug.Log("CatLevel: " + YG2.saves.catLevel);
        Debug.Log("CatCount: " + YG2.saves.catCount);

        _clickUpgrade.LoadFromCloud();
        _buyCatUpgrade.LoadFromCloud();
    }
}