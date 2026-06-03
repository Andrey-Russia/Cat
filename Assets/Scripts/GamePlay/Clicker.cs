using UnityEngine;

public class Clicker : MonoBehaviour
{
    public void Click()
    {
        CurrencyManager.Instance.AddCoins(
            PlayerStats.Instance.ClickPower);
    }
}