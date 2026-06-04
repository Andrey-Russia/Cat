using TMPro;
using UnityEngine;

public class IncomeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _incomeText;

    private void Update()
    {
        _incomeText.text =
            $"Доход: {AutoMinerManager.Instance.IncomePerSecond}/сек";
    }
}