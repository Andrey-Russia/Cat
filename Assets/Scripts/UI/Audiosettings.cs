using UnityEngine;
using YG;

public class AudioSettings : MonoBehaviour
{
    public static AudioSettings Instance { get; private set; }

    private bool _soundEnabled;

    public bool SoundEnabled => _soundEnabled;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        Load();
    }

    public void ToggleSound()
    {
        _soundEnabled = !_soundEnabled;

        Apply();

        Save();
    }

    private void Apply()
    {
        AudioListener.volume =
            _soundEnabled ? 1f : 0f;
    }

    private void Save()
    {
        YG2.saves.soundEnabled =
            _soundEnabled;

        YG2.SaveProgress();
    }

    private void Load()
    {
        _soundEnabled =
            YG2.saves.soundEnabled;

        Apply();
    }
}