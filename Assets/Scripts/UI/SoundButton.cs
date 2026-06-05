using TMPro;
using UnityEngine;
using YG;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Update()
    {
        _text.text =
            AudioSettings.Instance.SoundEnabled
            ? "Чтѓъ: ТЪЫ"
            : "Чтѓъ: ТлЪЫ";
    }
}