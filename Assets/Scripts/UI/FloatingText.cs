using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 100f;
    [SerializeField] private float _lifeTime = 1f;

    private TMP_Text _text;
    private Color _color;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();

        _color = _text.color;
    }

    public void SetText(string value)
    {
        _text.text = value;
    }

    private void Update()
    {
        transform.Translate(
            Vector3.up * _moveSpeed * Time.deltaTime);

        _color.a -= Time.deltaTime / _lifeTime;

        _text.color = _color;

        if (_color.a <= 0f)
        {
            Destroy(gameObject);
        }
    }
}