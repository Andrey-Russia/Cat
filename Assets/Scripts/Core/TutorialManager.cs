using TMPro;
using UnityEngine;
using YG;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }

    [SerializeField] private GameObject _tutorialPanel;
    [SerializeField] private TMP_Text _tutorialText;

    private int _currentStep;

    public int CurrentStep => _currentStep;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (YG2.saves.tutorialCompleted)
        {
            _tutorialPanel.SetActive(false);
            return;
        }

        _tutorialPanel.SetActive(true);

        ShowStep();
    }

    private void ShowStep()
    {
        switch (_currentStep)
        {
            case 0:
                _tutorialText.text =
                    "Нажмите на большого кота";
                break;

            case 1:
                _tutorialText.text =
                    "Купите улучшение Клик +1";
                break;

            case 2:
                _tutorialText.text =
                    "Купите Автокота";
                break;

            case 3:
                _tutorialText.text =
                    "Отлично! Теперь коты добывают монеты сами.\nНажмите ещё раз.";
                break;
        }
    }

    public void CompleteStep()
    {
        _currentStep++;

        if (_currentStep >= 4)
        {
            FinishTutorial();
            return;
        }

        ShowStep();
    }

    private void FinishTutorial()
    {
        _tutorialPanel.SetActive(false);

        YG2.saves.tutorialCompleted = true;

        YG2.SaveProgress();
    }
}