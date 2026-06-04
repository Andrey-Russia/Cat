using UnityEngine;
using YG;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }

    [SerializeField] private int _coins;

    public int Coins => _coins;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        _coins = YG2.saves.coins;

        if (YG2.saves.firstLaunch)
        {
            _coins = 40;

            YG2.saves.coins = 40;

            YG2.saves.lastExitTime =
                System.DateTime.UtcNow.ToString();

            YG2.saves.firstLaunch = false;

            YG2.SaveProgress();
        }
    }

    public void AddCoins(int amount)
    {
        _coins += amount;

        YG2.saves.coins = _coins;

        YG2.saves.totalCoinsEarned += amount;

        AchievementManager.Instance.CheckAchievements();
    }

    public bool SpendCoins(int amount)
    {
        if (_coins < amount)
            return false;

        _coins -= amount;

        YG2.saves.coins = _coins;

        return true;
    }

    public void LoadFromCloud()
    {
        _coins = YG2.saves.coins;
    }
}