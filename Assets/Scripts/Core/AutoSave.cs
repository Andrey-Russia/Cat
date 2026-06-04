using UnityEngine;
using YG;

public class AutoSave : MonoBehaviour
{
    [SerializeField] private float _saveDelay = 30f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _saveDelay)
        {
            _timer = 0;

            YG2.SaveProgress();
        }
    }
}