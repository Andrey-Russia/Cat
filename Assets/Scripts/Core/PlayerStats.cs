using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }

    [SerializeField] private int _clickPower = 1;

    public int ClickPower => _clickPower;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void IncreaseClickPower(int amount)
    {
        _clickPower += amount;
    }

    public void SetClickPower(int value)
    {
        _clickPower = value;
    }
}
