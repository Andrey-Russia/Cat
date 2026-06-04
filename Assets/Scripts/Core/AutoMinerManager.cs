using UnityEngine;

public class AutoMinerManager : MonoBehaviour
{
    public static AutoMinerManager Instance { get; private set; }

    [SerializeField] private int _catsCount;
    [SerializeField] private int _incomePerCat = 1;
    [SerializeField] private float _incomeMultiplier = 1f;
    [SerializeField] private float _speedMultiplier = 1f;

    private float _boostTimer;
    private float _speedBoostTimer;
    private float _timer;

    public int CatsCount => _catsCount;

    public int IncomePerSecond =>
     Mathf.RoundToInt(
         _catsCount *
         _incomePerCat *
         MineManager.Instance.CoinMultiplier *
         _incomeMultiplier);

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        if (_boostTimer > 0)
        {
            _boostTimer -= Time.deltaTime;

            if (_boostTimer <= 0)
            {
                _incomeMultiplier = 1f;
            }
        }

        if (_speedBoostTimer > 0)
        {
            _speedBoostTimer -= Time.deltaTime;

            if (_speedBoostTimer <= 0)
            {
                _speedMultiplier = 1f;
            }
        }

        _timer += Time.deltaTime * _speedMultiplier;

        if (_timer >= 1f)
        {
            _timer = 0f;

            int reward =
                Mathf.RoundToInt(
                    IncomePerSecond *
                    _incomeMultiplier);

            CurrencyManager.Instance.AddCoins(reward);
        }
    }

    public void AddCat()
    {
        _catsCount++;
    }

    public void ActivateIncomeBoost(
    float multiplier,
    float duration)
    {
        _incomeMultiplier = multiplier;
        _boostTimer = duration;
    }

    public void ActivateSpeedBoost(
        float multiplier,
        float duration)
    {
        _speedMultiplier = multiplier;
        _speedBoostTimer = duration;
    }
}