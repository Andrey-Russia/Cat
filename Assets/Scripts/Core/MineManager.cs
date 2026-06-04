using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
public class MineManager : MonoBehaviour
{
    public static MineManager Instance { get; private set; }

    [SerializeField] private TMP_Text _mineLevelText;
    [SerializeField] private Image _progressBar;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private Sprite[] _mineSprites;
    [SerializeField] private int[] _levelRequirments =
    {
         0,
        100,
        500,
        2000,
        10000,
        50000,
        250000,
        1000000
    };


    private int _currentMineLevel = 1;
    public int CurrentMineLevel => _currentMineLevel;
    public int CoinMultiplier => _currentMineLevel;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        UpdateMineLevel();
        UpdateProgressBar();
        UpdateBackground();

        _mineLevelText.text = $"Øàõòà LVL {_currentMineLevel}";
    }

    private void UpdateMineLevel()
    {
        int coins = YG2.saves.totalCoinsEarned;

        for (int i = _levelRequirments.Length - 1; i >= 0; i--)
        {
            if (coins >= _levelRequirments[i])
            {
                _currentMineLevel = i + 1;
                return;
            }
        }
    }

    private void UpdateProgressBar()
    {
        int currentIndex = _currentMineLevel - 1;

        if (currentIndex >= _levelRequirments.Length - 1)
        {
            _progressBar.fillAmount = 1f;
            return;
        }

        int currentRequirement =
            _levelRequirments[currentIndex];

        int nextRequirement =
            _levelRequirments[currentIndex + 1];

        float progress =
            (float)(CurrencyManager.Instance.Coins - currentRequirement)
            / (nextRequirement - currentRequirement);

        _progressBar.fillAmount = progress;
    }

    public void UpdateBackground()
    {
        int spriteIndex =
            Mathf.Clamp(
                _currentMineLevel - 1,
                0,
                _mineSprites.Length - 1);

        _backgroundImage.sprite =
            _mineSprites[spriteIndex];
    }
}
