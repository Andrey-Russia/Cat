using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }

    [SerializeField] private int _coins;

    private const string CoinsKey = "Coins";

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
        Load();
    }

    public void AddCoins(int amount)
    {
        _coins += amount;
        Save();
    }

    public bool SpendCoins(int amount)
    {
        if (_coins < amount)
            return false;

        _coins -= amount;
        Save();

        return true;
    }

    private void Save()
    {
        PlayerPrefs.SetInt(CoinsKey, _coins);
        PlayerPrefs.Save();
    }

    private void Load()
    {
        _coins = PlayerPrefs.GetInt(CoinsKey, 0);
    }
}