using TMPro;
using UnityEngine;

public class CatsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _catsText;

    private void Update()
    {
        _catsText.text =
            $"Cats: {AutoMinerManager.Instance.CatsCount}";
    }
}