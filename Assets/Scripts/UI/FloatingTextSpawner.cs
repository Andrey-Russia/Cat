using UnityEngine;

public class FloatingTextSpawner : MonoBehaviour
{
    public static FloatingTextSpawner Instance { get; private set; }

    [SerializeField] private FloatingText _floatingTextPrefab;

    [SerializeField] private RectTransform _catButton;

    [SerializeField] private Canvas _canvas;

    [SerializeField] private float _spawnRadius = 80f;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnText(int amount)
    {
        FloatingText text =
            Instantiate(
                _floatingTextPrefab,
                _canvas.transform);

        Vector3 randomOffset = new Vector3(
            Random.Range(-_spawnRadius, _spawnRadius),
            Random.Range(-_spawnRadius * 0.3f, _spawnRadius * 0.3f),
            0);

        text.transform.position =
            _catButton.position + randomOffset;

        text.SetText($"+{amount}");
    }
}