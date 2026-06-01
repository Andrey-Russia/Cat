using UnityEngine;
using TMPro; 
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(RectTransform))]
public class InteractiveButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [Header("Анимация")]
    [SerializeField] private Vector3 _defaultScale = new Vector3(1f, 1f, 1f);
    [SerializeField] private float _hoverScaleMultiplier = 1.2f;
    [SerializeField][Range(0.1f, 5f)] private float _scaleSpeed = 2f;

    [Header("Прозрачность (Текст)")]
    [SerializeField] private TMP_Text _buttonText; 
    [SerializeField][Range(0f, 1f)] private float _textDefaultAlpha = 1f;
    [SerializeField][Range(0f, 1f)] private float _textHoverMinAlpha = 0.6f;
    [SerializeField][Range(0.1f, 5f)] private float _alphaSpeed = 2f;

    [Header("Звук")]
    [SerializeField] private AudioClip _clickSound;
    [SerializeField][Range(0f, 1f)] private float _soundVolume = 1f;

    // --- Приватные поля ---
    private RectTransform _rectTransform;
    private Color _currentTextColor;
    private bool _isHovering = false;
    private Coroutine _animationCoroutine;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        if (_buttonText != null)
        {
            _currentTextColor = _buttonText.color;
            SetTextAlpha(_textDefaultAlpha);
        }

        _rectTransform.localScale = _defaultScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isHovering = true;
        StopAnimation();
        _animationCoroutine = StartCoroutine(AnimateButton());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isHovering = false;
        StopAnimation();
        _animationCoroutine = StartCoroutine(AnimateButton());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayClickSound();
    }

    private IEnumerator AnimateButton()
    {
        while (true)
        {
            Vector3 targetScale = _isHovering ? _defaultScale * _hoverScaleMultiplier : _defaultScale;
            float targetAlpha = _isHovering ? _textHoverMinAlpha : _textDefaultAlpha;

            _rectTransform.localScale = Vector3.Lerp(_rectTransform.localScale, targetScale, Time.unscaledDeltaTime * _scaleSpeed);

            if (_buttonText != null)
            {
                _currentTextColor.a = Mathf.Lerp(_currentTextColor.a, targetAlpha, Time.unscaledDeltaTime * _alphaSpeed);
                _buttonText.color = _currentTextColor;
            }

            bool scaleReached = Vector3.Distance(_rectTransform.localScale, targetScale) < 0.01f;
            bool alphaReached = _buttonText == null || Mathf.Abs(_currentTextColor.a - targetAlpha) < 0.01f;

            if (scaleReached && alphaReached)
            {
                break;
            }

            yield return null;
        }
    }

    private void StopAnimation()
    {
        if (_animationCoroutine != null)
        {
            StopCoroutine(_animationCoroutine);
            _animationCoroutine = null;
        }
    }

    private void PlayClickSound()
    {
        if (_clickSound == null) return;

        GameObject soundObject = new GameObject("OneShot Click Sound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.volume = _soundVolume;
        audioSource.PlayOneShot(_clickSound);
        Destroy(soundObject, _clickSound.length);
    }

    private void SetTextAlpha(float alpha)
    {
        if (_buttonText != null)
        {
            _currentTextColor.a = alpha;
            _buttonText.color = _currentTextColor;
        }
    }
}