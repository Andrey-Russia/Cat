using UnityEngine;

public class Clicker : MonoBehaviour
{
    public void Click()
    {
        int reward =
            PlayerStats.Instance.ClickPower *
            MineManager.Instance.CoinMultiplier;

        CurrencyManager.Instance.AddCoins(reward);

        FloatingTextSpawner.Instance.SpawnText(reward);

        if (TutorialManager.Instance.CurrentStep == 0)
        {
            TutorialManager.Instance.CompleteStep();
        }
    }
}