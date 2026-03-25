using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    public TextMeshProUGUI tutorialText;
    public GameObject tutorialPanel;

    [TextArea(2, 4)]
    public string[] steps;

    private int currentStep = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
        }
    }

    public void ShowCurrentStep()
    {
        if (currentStep < steps.Length)
        {
            if (tutorialPanel != null)
            {
                tutorialPanel.SetActive(true);
            }

            if (tutorialText != null)
            {
                tutorialText.text = steps[currentStep];
            }
        }
        else
        {
            if (tutorialPanel != null)
            {
                tutorialPanel.SetActive(false);
            }
        }
    }

    public void NextStep()
    {
        currentStep++;
        ShowCurrentStep();
    }
}
