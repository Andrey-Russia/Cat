using System.Collections.Generic;
using UnityEngine;

public class MiniCatSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _miniCatPrefab;
    [SerializeField] private Transform _container;

    private readonly List<GameObject> _spawnedCats = new();

    public void SpawnCat()
    {
        GameObject cat =
            Instantiate(
                _miniCatPrefab,
                _container);

        _spawnedCats.Add(cat);

        UpdatePositions();
    }

    private void UpdatePositions()
    {
        float radius = 500f;

        for (int i = 0; i < _spawnedCats.Count; i++)
        {
            float angle =
                i * Mathf.PI * 2f / _spawnedCats.Count;

            Vector2 position =
                new(
                    Mathf.Cos(angle) * radius,
                    Mathf.Sin(angle) * radius);

            _spawnedCats[i]
                .GetComponent<RectTransform>()
                .anchoredPosition = position;
        }
    }
}