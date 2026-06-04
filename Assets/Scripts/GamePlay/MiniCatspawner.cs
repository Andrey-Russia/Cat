using System.Collections.Generic;
using UnityEngine;

public class MiniCatSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _miniCatPrefab;
    [SerializeField] private RectTransform _container;

    [SerializeField] private float _radius = 250f;

    private readonly List<RectTransform> _cats = new();

    public void SpawnCat()
    {
        GameObject cat =
            Instantiate(
                _miniCatPrefab,
                _container);

        RectTransform rect =
            cat.GetComponent<RectTransform>();

        _cats.Add(rect);

        RebuildCircle();
    }

    private void RebuildCircle()
    {
        int count = _cats.Count;

        if (count == 0)
            return;

        if (count == 1)
        {
            _cats[0].anchoredPosition = Vector2.zero;
            return;
        }

        for (int i = 0; i < count; i++)
        {
            float angle =
                (360f / count) * i;

            float rad =
                angle * Mathf.Deg2Rad;

            Vector2 pos =
                new Vector2(
                    Mathf.Cos(rad),
                    Mathf.Sin(rad))
                * _radius;

            _cats[i].anchoredPosition = pos;
        }
    }
}