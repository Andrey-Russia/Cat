using UnityEngine;

public class AutoMinerManager : MonoBehaviour
{
    public static AutoMinerManager Instance {  get; private set; }

    [SerializeField] private int _catsCount;
    [SerializeField] private int _incomePerCat = 1;

    private float _timer;
    public int CatsCount => _catsCount;

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
        _timer += Time.deltaTime;

        if (_timer >= 1f)
        {
            _timer = 0f;

            CurrencyManager.Instance.AddCoins(_catsCount * _incomePerCat);
        }
    }

    public void AddCat()
    {
        _catsCount++;
    }
}
