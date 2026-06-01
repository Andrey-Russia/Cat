using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    [SerializeField] private GameObject _targetPanel;

    private void Start()
    {
        _targetPanel.SetActive(false);
    }

    public void ShowPanel()
    {
        if (_targetPanel != null)
            _targetPanel.SetActive(true);
    }

    public void HidePanel()
    {
        if (_targetPanel != null)
            _targetPanel.SetActive(false);
    }
}